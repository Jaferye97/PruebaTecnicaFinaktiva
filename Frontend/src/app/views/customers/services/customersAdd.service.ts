import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { Observable } from 'rxjs';

import { Customer, CustomerFormAdd } from '../interfaces/customersAdd';

@Injectable({
  providedIn: 'root',
})
export class CustomersAddService {
  constructor(private http: HttpClient) {}

  AddCustomer(customer: CustomerFormAdd): Observable<Customer> {
    const urlConsulta = `${environment.urlInicial}${urlServices.customers}`;
    return this.http.post<Customer>(urlConsulta, customer);
  }
}
