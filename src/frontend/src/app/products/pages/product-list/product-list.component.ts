import { ProductDataService } from "../../services/product-data.service";
import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../../models/product";
import { delay, tap } from "rxjs/operators";


@Component({
    selector: "app-product-list",
    templateUrl: "./product-list.component.html",
    styleUrls: ["./product-list.component.scss"]
})
export class ProductListComponent implements OnInit {
    public products$: Observable<Product[]>;
    public isLoading = false;

    constructor(private productData: ProductDataService) { }

    ngOnInit() {
        this.isLoading = true;
        this.products$ = this.productData.getAll()
        .pipe(
            tap(_ => this.isLoading = false)
        );
    }
}
