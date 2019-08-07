import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { ProductListComponent } from "./product-list/product-list.component";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";

@NgModule({
    declarations: [ProductListComponent],
    exports: [ProductListComponent],
    imports: [CommonModule, HttpClientModule, MatCardModule, MatButtonModule]
})
export class ProductsModule {}
