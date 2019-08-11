import { NgModule } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";

@NgModule({
    imports: [MatCardModule, MatButtonModule, MatInputModule],
    exports: [MatCardModule, MatButtonModule, MatInputModule]
})
export class MaterialModule {}
