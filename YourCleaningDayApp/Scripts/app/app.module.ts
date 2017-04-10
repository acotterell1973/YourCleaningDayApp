///<reference path="../../typings/globals/core-js/index.d.ts"/>
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import "rxjs/Rx";

import AppComponent = require("./app.comonent");

@NgModule({
    declarations: [
        AppComponent.AppComponent
    ],
    imports: [
        BrowserModule,
        HttpModule
    ],
    providers: [
    ],
    bootstrap: [
        AppComponent.AppComponent
    ]
})
export class AppModule { }