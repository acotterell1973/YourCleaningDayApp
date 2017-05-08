///<reference path="../../typings/globals/core-js/index.d.ts"/>
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import "rxjs/Rx";
import { AppComponent } from "./app.comonent";
import { EmployeeListComponent } from "./employee-list.component";
import { EmployeeService } from "./employee.service";
import { CustomerListComponent } from "./customer-list.component";
import { CustomerService } from "./customer.service";



@NgModule({
    declarations: [
        AppComponent, 
        CustomerListComponent,
        EmployeeListComponent
    ],
    imports: [
        BrowserModule,
        HttpModule
    ],
    providers: [
        CustomerService,
        EmployeeService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }