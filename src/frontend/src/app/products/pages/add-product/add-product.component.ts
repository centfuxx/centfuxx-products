import { ProductFormComponent } from "./../../components/product-form/product-form.component";
import { ProductDataService } from "./../../services/product-data.service";
import { Component, OnInit, ViewChild } from "@angular/core";
import { Product } from "../../models/product";
import { Router } from "@angular/router";

@Component({
    selector: "app-add-product",
    templateUrl: "./add-product.component.html",
    styleUrls: ["./add-product.component.scss"]
})
export class AddProductComponent implements OnInit {
    @ViewChild("productForm", { static: true })
    public productForm: ProductFormComponent;

    constructor(
        private router: Router,
        private productService: ProductDataService
    ) {}

    ngOnInit() {}

    cancel() {
        this.toList();
    }

    save() {
        const currentFormValue = this.productForm.formGroup.value;
        const product = {
            name: currentFormValue.name,
            description: currentFormValue.description
        } as Product;
        this.productService
            .save(product)
            .toPromise()
            .then(_ => this.toList());
    }

    private toList() {
        this.router.navigate(["../list"]);
    }
}
