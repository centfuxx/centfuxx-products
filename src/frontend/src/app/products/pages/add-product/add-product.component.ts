import { ProductDataService } from "./../../services/product-data.service";
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Product } from "../../models/product";
import { Router } from "@angular/router";

@Component({
    selector: "app-add-product",
    templateUrl: "./add-product.component.html",
    styleUrls: ["./add-product.component.scss"]
})
export class AddProductComponent implements OnInit {
    public formGroup: FormGroup;
    public descriptionMaxLength = 255;

    constructor(
        private router: Router,
        private formBuilder: FormBuilder,
        private productService: ProductDataService
    ) {}

    ngOnInit() {
        this.formGroup = this.formBuilder.group({
            name: ["", Validators.required],
            description: ["", Validators.maxLength(this.descriptionMaxLength)]
        });
    }

    cancel() {
        this.toList();
    }

    save() {
        const currentFormValue = this.formGroup.value;
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
