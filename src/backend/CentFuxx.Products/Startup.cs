using System.Configuration;
using System.IO;
using AutoMapper;
using CentFuxx.Products.Domain.Products;
using CentFuxx.Products.Storage.EfCore;
using CentFuxx.Products.Storage.EfCore.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CentFuxx.Products
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<ProductsContext>(options =>
            {
                switch (Configuration["Storage"])
                {
                    case "MySQL":
                        options.UseMySQL(
                            Configuration.GetConnectionString("MySQL"),
                            opt => opt.MigrationsAssembly(typeof(MySqlProductContext).Assembly.FullName));
                        break;
                    default:
                        throw new ConfigurationErrorsException("No storage configured");
                }
            });

            services.AddScoped<ProductsRepository, EfCoreProductsRepository>();

            services.AddAutoMapper(typeof(Api.Products.Product).Assembly);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowCredentials().AllowAnyMethod());
            app.UseHttpsRedirection();
            app.UseMvc();

            // Host static files in wwwroot folder
            var defaultFileOptions = new DefaultFilesOptions();
            defaultFileOptions.DefaultFileNames.Clear();
            defaultFileOptions.DefaultFileNames.Add("/index.html");
            app.UseDefaultFiles(defaultFileOptions);
            app.UseStaticFiles();

            // Fallback for URL routing in Angular application
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404
                    && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    context.Response.StatusCode = 200;
                    await next();
                }
            });
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                switch (Configuration["Storage"])
                {
                    case "MySQL":
                        using (var context = serviceScope.ServiceProvider.GetService<ProductsContext>())
                        {
                            context.Database.Migrate();
                        }
                        break;

                    default:
                        throw new ConfigurationErrorsException("No storage configured");
                }
            }
        }
    }
}
