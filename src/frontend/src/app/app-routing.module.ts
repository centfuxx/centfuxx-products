import { ProductsModule } from "./products/products.module";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
    { path: "", redirectTo: "/products", pathMatch: "full" },
    { path: "products", loadChildren: () => import("./products/products.module").then(mod => mod.ProductsModule)}
];


@NgModule({
    imports: [RouterModule.forRoot(routes), ProductsModule],
    exports: [RouterModule]
})
export class AppRoutingModule {}
