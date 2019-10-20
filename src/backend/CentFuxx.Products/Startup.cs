using System;
using System.IO;
using AutoMapper;
using CentFuxx.Products.Application.Repositories;
using CentFuxx.Products.Domain.Products;
using CentFuxx.Products.Storage.EfCore;
using CentFuxx.Products.Storage.EfCore.MySql;
using CentFuxx.Products.Storage.EfCore.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            switch (Configuration["Storage"])
            {
                case "MySQL":
                    services.AddDbContext<ProductsContext>(options =>
                    {
                        options.UseMySql(
                            Configuration.GetConnectionString("MySQL"),
                            opt => opt.MigrationsAssembly("CentFuxx.Products.Storage.EfCore.MySql"));
                    });

                    break;

                default:
                    throw new InvalidOperationException("No storage configured");
            }

            services.AddApplication();
            

            services.AddAutoMapper(typeof(Api.Products.Product).Assembly);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            UpdateDatabase(app, loggerFactory);

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

        private void UpdateDatabase(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            using (app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                switch (Configuration["Storage"])
                {
                    case "MySQL":
                        var optionsBuilder = new DbContextOptionsBuilder<MySqlProductContext>();
                        optionsBuilder
                            .UseMySql(
                                Configuration.GetConnectionString("MySQL"),
                                opt => opt.MigrationsAssembly(typeof(MySqlProductContext).Assembly.GetName().Name))
                            .UseLoggerFactory(loggerFactory);
                        using (var context = new MySqlProductContext(optionsBuilder.Options))
                        {
                            context.Database.Migrate();
                        }
                        break;

                    default:
                        throw new InvalidOperationException("No storage configured");
                }
            }
        }
    }
}
