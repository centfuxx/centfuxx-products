import { MaterialModule } from "./../material/material.module";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { ProductListComponent } from "./pages/product-list/product-list.component";
import { ProductCardComponent } from "./components/product-card/product-card.component";
import { AddProductComponent } from "./pages/add-product/add-product.component";
import { RouterModule, Routes } from "@angular/router";
import { ProductsComponent } from "./components/products/products.component";

const routes: Routes = [
    {
        path: "",
        component: ProductsComponent,
        children: [
            { path: "list", component: ProductListComponent },
            { path: "add", component: AddProductComponent },
            { path: "", redirectTo: "list", pathMatch: "full" }
        ]
    }
];

@NgModule({
    declarations: [
        ProductListComponent,
        ProductCardComponent,
        AddProductComponent,
        ProductsComponent
    ],
    exports: [ProductListComponent],
    imports: [
        RouterModule.forChild(routes),
        CommonModule,
        HttpClientModule,
        MaterialModule
    ]
})
export class ProductsModule {}
