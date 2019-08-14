import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import {
    Component,
    OnInit,
    Input,
    OnChanges,
    SimpleChanges
} from "@angular/core";
import { Product } from "../../models/product";

@Component({
    selector: "app-product-form",
    templateUrl: "./product-form.component.html",
    styleUrls: ["./product-form.component.scss"]
})
export class ProductFormComponent implements OnInit, OnChanges {
    @Input() public product: Product;

    // tslint:disable-next-line:variable-name
    private _formGroup: FormGroup;

    public descriptionMaxLength = 255;

    constructor(private formBuilder: FormBuilder) {
        this._formGroup = this.formBuilder.group({
            name: ["", Validators.required],
            description: ["", Validators.maxLength(this.descriptionMaxLength)]
        });
    }

    ngOnInit() {}

    ngOnChanges(changes: SimpleChanges): void {
        if (!this._formGroup) {
            return;
        }

        this._formGroup.patchValue({
            id: this.product.id,
            name: this.product.name,
            description: this.product.description
        });
    }

    get formGroup() {
        return this._formGroup;
    }
}
