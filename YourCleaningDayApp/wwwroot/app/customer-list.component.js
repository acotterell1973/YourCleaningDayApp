System.register(["@angular/core","./customer.service"],function(exports_1,context_1){"use strict";var core_1,customer_service_1,CustomerListComponent,__decorate=this&&this.__decorate||function(decorators,target,key,desc){var d,c=arguments.length,r=c<3?target:null===desc?desc=Object.getOwnPropertyDescriptor(target,key):desc;if("object"==typeof Reflect&&"function"==typeof Reflect.decorate)r=Reflect.decorate(decorators,target,key,desc);else for(var i=decorators.length-1;i>=0;i--)(d=decorators[i])&&(r=(c<3?d(r):c>3?d(target,key,r):d(target,key))||r);return c>3&&r&&Object.defineProperty(target,key,r),r},__metadata=this&&this.__metadata||function(k,v){if("object"==typeof Reflect&&"function"==typeof Reflect.metadata)return Reflect.metadata(k,v)};context_1&&context_1.id;return{setters:[function(core_1_1){core_1=core_1_1},function(customer_service_1_1){customer_service_1=customer_service_1_1}],execute:function(){CustomerListComponent=function(){function CustomerListComponent(customerService){this.customerService=customerService}return CustomerListComponent.prototype.ngOnInit=function(){this.getCustomers()},CustomerListComponent.prototype.getCustomers=function(){var _this=this;this.customerService.getMostRecent().subscribe(function(allCustomers){return _this.customers=allCustomers},function(error){return _this.errorMessage=error})},CustomerListComponent.prototype.onSelect=function(customer){this.selectedCustomer=customer},CustomerListComponent}(),CustomerListComponent=__decorate([core_1.Component({selector:"customer-list",template:"<h2>Customers:</h2><ul class=\"customers\"><li *ngFor='let customer of customers' [class.selected]='customer === selectedCustomer' (click)='onSelect(customer)'><span>{{customer.FirstName}}</span></li></ul>",styles:["ul.customers li {cursor: pointer;} ul.customer li.selected {background-color: #cccccc}"]}),__metadata("design:paramtypes",[customer_service_1.CustomerService])],CustomerListComponent),exports_1("CustomerListComponent",CustomerListComponent)}}});
//# sourceMappingURL=customer-list.component.js.map