import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { Observable } from 'rxjs';

import { Customer, CustomerFormUpdate } from '../interfaces/customersUpdate';

@Injectable({
  providedIn: 'root',
})
export class CustomersUpdateService {
  constructor(private http: HttpClient) {}

  GetCustomer(id: string): Observable<Customer> {
    const urlConsulta = `${environment.urlInicial}${urlServices.customers}/${id}`;
    return this.http.get<Customer>(urlConsulta);
  }

  UpdateCustomer(customer: CustomerFormUpdate): Observable<Customer> {
    const urlConsulta = `${environment.urlInicial}${urlServices.customers}`;
    return this.http.put<Customer>(urlConsulta, customer);
  }
}
