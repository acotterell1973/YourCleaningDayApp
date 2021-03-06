System.register(["@angular/core", "@angular/platform-browser", "@angular/http", "rxjs/Rx", "./app.comonent", "./employee-list.component", "./employee.service", "./customer-list.component", "./customer.service"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, platform_browser_1, http_1, app_comonent_1, employee_list_component_1, employee_service_1, customer_list_component_1, customer_service_1, AppModule;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (_1) {
            },
            function (app_comonent_1_1) {
                app_comonent_1 = app_comonent_1_1;
            },
            function (employee_list_component_1_1) {
                employee_list_component_1 = employee_list_component_1_1;
            },
            function (employee_service_1_1) {
                employee_service_1 = employee_service_1_1;
            },
            function (customer_list_component_1_1) {
                customer_list_component_1 = customer_list_component_1_1;
            },
            function (customer_service_1_1) {
                customer_service_1 = customer_service_1_1;
            }
        ],
        execute: function () {
            AppModule = (function () {
                function AppModule() {
                }
                return AppModule;
            }());
            AppModule = __decorate([
                core_1.NgModule({
                    declarations: [
                        app_comonent_1.AppComponent,
                        customer_list_component_1.CustomerListComponent,
                        employee_list_component_1.EmployeeListComponent
                    ],
                    imports: [
                        platform_browser_1.BrowserModule,
                        http_1.HttpModule
                    ],
                    providers: [
                        customer_service_1.CustomerService,
                        employee_service_1.EmployeeService
                    ],
                    bootstrap: [
                        app_comonent_1.AppComponent
                    ]
                })
            ], AppModule);
            exports_1("AppModule", AppModule);
        }
    };
});
//# sourceMappingURL=app.module.js.map