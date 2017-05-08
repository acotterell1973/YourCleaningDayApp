import { Component, OnInit } from "@angular/core";
import { Customer } from "./customer";
import { CustomerService } from "./customer.service";

@Component(
    {
        selector: "customer-list",
        template:
        "<h2>Customers:</h2>" +
        '<ul class="customers">' +
        "<li *ngFor='let customer of customers' " +
        "[class.selected]='customer === selectedCustomer' " +
        "(click)='onSelect(customer)'>" +
        "<span>{{customer.FirstName}}</span></li></ul>"
        ,
        styles: [
            "ul.customers li {cursor: pointer;} " +
            "ul.customer li.selected {background-color: #cccccc}"
        ]
    })

export class CustomerListComponent implements OnInit {
    selectedCustomer: Customer;
    customers: Customer[];
    errorMessage: string;

    constructor(private customerService: CustomerService) { }

    ngOnInit() {
        this.getCustomers();
    }

    getCustomers() {
        this.customerService.getMostRecent()
            .subscribe(
            allCustomers => this.customers = allCustomers,
            error => this.errorMessage = <any>error
            );
    }

    onSelect(customer: Customer) {
        this.selectedCustomer = customer;
    }
}