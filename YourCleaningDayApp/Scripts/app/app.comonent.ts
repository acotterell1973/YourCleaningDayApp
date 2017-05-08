import { Component } from "@angular/core";

@Component({
    selector: "yourcleaningday",
    template: "<h1>{{title}}</h1>" +
        "<customer-list></customer-list>"
})

export class AppComponent {
    title="Your Cleaning Day Manager";
}
