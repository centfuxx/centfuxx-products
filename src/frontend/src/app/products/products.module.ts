import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { ProductListComponent } from "./product-list/product-list.component";
import { ProductCardComponent } from "./product-card/product-card.component";

@NgModule({
    declarations: [ProductListComponent, ProductCardComponent],
    exports: [ProductListComponent],
    imports: [CommonModule, HttpClientModule, MatCardModule, MatButtonModule]
})
export class ProductsModule {}
