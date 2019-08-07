import { ProductDataService } from "./../services/product-data.service";
import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../models/product";

@Component({
    selector: "app-product-list",
    templateUrl: "./product-list.component.html",
    styleUrls: ["./product-list.component.scss"]
})
export class ProductListComponent implements OnInit {
    public products$: Observable<Product[]>;

    constructor(private productData: ProductDataService) {}

    ngOnInit() {
        this.products$ = this.productData.getAll();
    }
}
