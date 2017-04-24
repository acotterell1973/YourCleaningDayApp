import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Employee } from "./employee";

@Injectable()
export class EmployeeService {
    constructor(private http: Http) { }
    private baseUrl = "api/staff/";

    getEmployees() {
        var url = this.baseUrl + "getemployees/";
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    getEmployee(id: Number) {
        
        if (id == null) {
            throw new Error("id is required");
        }
        var url = this.baseUrl + id;
        return this.http.get(url)
            .map(response => <Employee>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "Server Error");
    }
}