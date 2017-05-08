System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Customer;
    return {
        setters: [],
        execute: function () {
            Customer = (function () {
                function Customer(customerId, firstName, lastName, gender, phoneNumber, emailAddress, address1, address2, city, state, zip) {
                    this.customerId = customerId;
                    this.firstName = firstName;
                    this.lastName = lastName;
                    this.gender = gender;
                    this.phoneNumber = phoneNumber;
                    this.emailAddress = emailAddress;
                    this.address1 = address1;
                    this.address2 = address2;
                    this.city = city;
                    this.state = state;
                    this.zip = zip;
                }
                return Customer;
            }());
            exports_1("Customer", Customer);
        }
    };
});
//# sourceMappingURL=customer.js.map