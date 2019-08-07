import { Product } from "./../models/product";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: "root"
})
export class ProductDataService {
    private static readonly URI = "api/products";

    constructor(private http: HttpClient) {}

    public getAll() {
        return this.http.get<Product[]>(
            `${environment.baseUrI}${ProductDataService.URI}`
        );
    }
}
