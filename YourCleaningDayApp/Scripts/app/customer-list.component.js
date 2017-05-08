System.register(["@angular/core", "./customer.service"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, customer_service_1, CustomerListComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (customer_service_1_1) {
                customer_service_1 = customer_service_1_1;
            }
        ],
        execute: function () {
            CustomerListComponent = (function () {
                function CustomerListComponent(customerService) {
                    this.customerService = customerService;
                }
                CustomerListComponent.prototype.ngOnInit = function () {
                    this.getCustomers();
                };
                CustomerListComponent.prototype.getCustomers = function () {
                    var _this = this;
                    this.customerService.getMostRecent()
                        .subscribe(function (allCustomers) { return _this.customers = allCustomers; }, function (error) { return _this.errorMessage = error; });
                };
                CustomerListComponent.prototype.onSelect = function (customer) {
                    this.selectedCustomer = customer;
                };
                return CustomerListComponent;
            }());
            CustomerListComponent = __decorate([
                core_1.Component({
                    selector: "customer-list",
                    template: "<h2>Customers:</h2>" +
                        '<ul class="customers">' +
                        "<li *ngFor='let customer of customers' " +
                        "[class.selected]='customer === selectedCustomer' " +
                        "(click)='onSelect(customer)'>" +
                        "<span>{{customer.FirstName}}</span></li></ul>",
                    styles: [
                        "ul.customers li {cursor: pointer;} " +
                            "ul.customer li.selected {background-color: #cccccc}"
                    ]
                }),
                __metadata("design:paramtypes", [customer_service_1.CustomerService])
            ], CustomerListComponent);
            exports_1("CustomerListComponent", CustomerListComponent);
        }
    };
});
//# sourceMappingURL=customer-list.component.js.map