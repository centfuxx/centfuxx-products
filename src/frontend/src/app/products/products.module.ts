import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { ProductListComponent } from "./product-list/product-list.component";
import { ProductCardComponent } from "./product-card/product-card.component";
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
        CommonModule,
        HttpClientModule,
        MatCardModule,
        MatButtonModule,
        RouterModule.forChild(routes)
    ]
})
export class ProductsModule {}
