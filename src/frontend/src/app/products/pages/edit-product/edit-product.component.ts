import { ProductFormComponent } from "./../../components/product-form/product-form.component";
import { ProductDataService } from "./../../services/product-data.service";
import {
    Component,
    OnInit,
    OnDestroy,
    AfterViewInit,
    QueryList,
    ViewChildren
} from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable, Subscription, of } from "rxjs";
import { switchMap } from "rxjs/operators";
import { Product } from "../../models/product";

@Component({
    selector: "app-edit-product",
    templateUrl: "./edit-product.component.html",
    styleUrls: ["./edit-product.component.scss"]
})
export class EditProductComponent implements OnInit, OnDestroy, AfterViewInit {
    private subscriptions: Subscription[] = [];

    public productId: number;
    public product$: Observable<Product>;

    @ViewChildren("productForm")
    public productFormList: QueryList<ProductFormComponent>;
    public productForm: ProductFormComponent;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private productService: ProductDataService
    ) {}

    ngOnInit() {
        this.product$ = this.route.paramMap.pipe(
            switchMap(params =>
                this.productService.get(Number(params.get("id")))
            )
        );
    }

    ngAfterViewInit(): void {
        this.subscriptions.push(
            this.productFormList.changes.subscribe(
                (forms: QueryList<ProductFormComponent>) =>
                    (this.productForm = forms.first)
            )
        );
    }

    ngOnDestroy(): void {
        this.subscriptions.forEach(item => item.unsubscribe());
        this.subscriptions = [];
    }

    save() {
        const currentFormValue = this.productForm.formGroup.value;
        const product = {
            id: Number(this.route.snapshot.params.id),
            name: currentFormValue.name,
            description: currentFormValue.description
        } as Product;
        this.productService
            .save(product)
            .toPromise()
            .then(_ => this.toList());
    }

    cancel() {
        this.toList();
    }

    private toList() {
        this.router.navigate(["../list"]);
    }
}
