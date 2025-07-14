import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../enviroment';
import { Customer } from '../models/customer.models';

@Injectable({
  providedIn: 'root'
})
export class CustomerServce {

    private http = inject(HttpClient);
    private apiUrl = environment.apiUrl + 'Customer';

    getCustomers() {
        return this.http.get<Customer[]>(this.apiUrl);
    }
    getCustomerById(id: string) {
        return this.http.get<Customer>(`${this.apiUrl}/${id}`);
    }

    createCustomer(customer: any) {
        return this.http.post<Customer>(this.apiUrl, customer);
    }

    updateCustomer(id : string,customer: any) {
        return this.http.put<any>(`${this.apiUrl}/${id}`, customer);
    }

    deleteCustomer(id: string) {
        return this.http.delete(`${this.apiUrl}/${id}`);
    }
}
