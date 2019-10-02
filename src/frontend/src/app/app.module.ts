import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FlexLayoutModule } from "@angular/flex-layout";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatToolbarModule } from "@angular/material/toolbar";
import { ProductsModule } from "./products/products.module";

@NgModule({
    declarations: [AppComponent],
    imports: [
        FlexLayoutModule,
        BrowserAnimationsModule,
        BrowserModule,
        AppRoutingModule,
        MatToolbarModule,
        ProductsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {}
