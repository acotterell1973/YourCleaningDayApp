///<reference path="../../typings/globals/core-js/index.d.ts"/>
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import "rxjs/Rx";
import { AppComponent } from "./app.comonent";
import { EmployeeListComponent } from "./employee-list.component";
import { EmployeeService } from "./employee.service";


@NgModule({
    declarations: [
        AppComponent, 
        EmployeeListComponent
    ],
    imports: [
        BrowserModule,
        HttpModule
    ],
    providers: [
        EmployeeService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }