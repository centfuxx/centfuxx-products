import { ProductsModule } from "./products/products.module";
import { ProductListComponent } from "./products/product-list/product-list.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ProductsComponent } from "./products/components/products/products.component";

const routes: Routes = [
    { path: "", redirectTo: "/products", pathMatch: "full" },
    { path: "products", loadChildren: () => import("./products/products.module").then(mod => mod.ProductsModule)}
];


@NgModule({
    imports: [RouterModule.forRoot(routes), ProductsModule],
    exports: [RouterModule]
})
export class AppRoutingModule {}
