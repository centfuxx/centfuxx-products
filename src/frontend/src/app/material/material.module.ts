import { NgModule } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatIconModule } from "@angular/material/icon";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";

@NgModule({
    imports: [
        MatCardModule,
        MatButtonModule,
        MatInputModule,
        MatIconModule,
        MatProgressSpinnerModule
    ],
    exports: [
        MatCardModule,
        MatButtonModule,
        MatInputModule,
        MatIconModule,
        MatProgressSpinnerModule
    ]
})
export class MaterialModule { }
