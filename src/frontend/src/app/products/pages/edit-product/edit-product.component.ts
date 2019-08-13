import { ProductDataService } from "./../../services/product-data.service";
import { Component, OnInit, OnDestroy } from "@angular/core";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { Observable, Subscription, of } from "rxjs";
import { tap, switchMap } from "rxjs/operators";
import { Product } from "../../models/product";
import { ɵangular_packages_forms_forms_a } from "@angular/forms";

@Component({
    selector: "app-edit-product",
    templateUrl: "./edit-product.component.html",
    styleUrls: ["./edit-product.component.scss"]
})
export class EditProductComponent implements OnInit, OnDestroy {
    private subscriptions: Subscription[] = [];

    public productId: number;
    public product$: Observable<Product>;

    constructor(
        private route: ActivatedRoute,
        private products: ProductDataService
    ) {}

    ngOnInit() {
        this.product$ = this.route.paramMap.pipe(
            switchMap(params => this.products.get(Number(params.get("id")))),
            tap(p => console.log(p))
        );
    }

    ngOnDestroy(): void {
        this.subscriptions.forEach(item => item.unsubscribe());
        this.subscriptions = [];
    }
}
