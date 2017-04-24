import { Component, OnInit } from "@angular/core";
import { Employee } from "./employee";
import { EmployeeService } from "./employee.service";

@Component({
    selector: "employee-list",
    template: "<h2>Employees </h2>",
    styles: []
})

export class EmployeeListComponent implements OnInit {
    selectedEmployee: Employee;
    employees: Employee[];
    errorMessage: string;

    constructor(private employeeService: EmployeeService) { }

    ngOnInit() { this.getEmployees() };

    getEmployees() {
        this.employeeService.getEmployees()
            .subscribe(employees => this.employees = employees,
            error => this.errorMessage = <any>error);
    }

    onSelect(employee: Employee) {
        this.selectedEmployee = employee;
    }
}