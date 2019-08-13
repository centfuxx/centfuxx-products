import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Component, OnInit, Input } from "@angular/core";
import { Product } from "../../models/product";

@Component({
    selector: "app-product-form",
    templateUrl: "./product-form.component.html",
    styleUrls: ["./product-form.component.scss"]
})
export class ProductFormComponent implements OnInit {
    @Input() public product: Product;

    // tslint:disable-next-line:variable-name
    private _formGroup: FormGroup;

    public descriptionMaxLength = 255;

    constructor(private formBuilder: FormBuilder) {}

    ngOnInit() {
        this._formGroup = this.formBuilder.group({
            name: ["", Validators.required],
            description: ["", Validators.maxLength(this.descriptionMaxLength)]
        });
    }

    get formGroup() {
        return this._formGroup;
    }
}
