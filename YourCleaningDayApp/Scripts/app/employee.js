System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Employee;
    return {
        setters: [],
        execute: function () {
            Employee = (function () {
                function Employee(id, employeeId, firstName, lastName) {
                    this.id = id;
                    this.employeeId = employeeId;
                    this.firstName = firstName;
                    this.lastName = lastName;
                }
                return Employee;
            }());
            exports_1("Employee", Employee);
        }
    };
});
//# sourceMappingURL=employee.js.map