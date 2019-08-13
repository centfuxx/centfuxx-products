import { Product } from "./../models/product";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";

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

    public save(product: Product) {
        return this.http.post<Product>(
            `${environment.baseUrI}${ProductDataService.URI}`,
            product
        );
    }

    get(id: number): Observable<Product> {
        return this.http.get<Product>(
            `${environment.baseUrI}${ProductDataService.URI}/${id}`
        );
    }
}
