System.register(["@angular/core", "@angular/http", "rxjs/Observable"], function (exports_1, context_1) {
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
    var core_1, http_1, Observable_1, CustomerService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            }
        ],
        execute: function () {
            CustomerService = (function () {
                function CustomerService(http) {
                    this.http = http;
                    this.baseUrl = "api/customer/";
                }
                // calls the [GET] /api/customer/mostrecent Web API 
                CustomerService.prototype.getMostRecent = function (num) {
                    var url = this.baseUrl + "mostrecent";
                    if (num != null) {
                        url += num;
                    }
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                // calls the [GET] /api/customer/ Web API 
                CustomerService.prototype.getAll = function () {
                    var url = this.baseUrl;
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                // calls the [GET] /api/customer/ Web API 
                CustomerService.prototype.getCustomer = function (id) {
                    var url = this.baseUrl;
                    if (id == null) {
                        throw new Error("id is required.");
                    }
                    return this.http.get(url + id)
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                CustomerService.prototype.handleError = function (err, caught) {
                    console.error(err);
                    return Observable_1.Observable.throw(err.json().error || "Server error");
                };
                return CustomerService;
            }());
            CustomerService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [http_1.Http])
            ], CustomerService);
            exports_1("CustomerService", CustomerService);
        }
    };
});
//# sourceMappingURL=customer.service.js.map