import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Customer } from "./customer";

@Injectable()
export class CustomerService {
    constructor(private http: Http) { }

    private baseUrl = "api/customer/";

    // calls the [GET] /api/customer/mostrecent Web API 
    getMostRecent(num?: number) {
        var url = this.baseUrl + "mostrecent";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/customer/ Web API 
    getAll() {
        var url = this.baseUrl;
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/customer/ Web API 
    getCustomer(id: number) {
        var url = this.baseUrl;
        if (id == null) {
            throw new Error("id is required.");
        }
        return this.http.get(url + id)
            .map(response => <Customer>response.json())
            .catch(this.handleError);
    }

    private handleError(err: Response, caught: Observable<Object>) {
        console.error(err);
        return Observable.throw(err.json().error || "Server error");
    }

}
