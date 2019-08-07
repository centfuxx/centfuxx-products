import { ProductsModule } from "./products/products.module";
import { ProductListComponent } from "./products/product-list/product-list.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: ProductListComponent,
    pathMatch: "full"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ProductsModule],
  exports: [RouterModule]
})
export class AppRoutingModule {}
