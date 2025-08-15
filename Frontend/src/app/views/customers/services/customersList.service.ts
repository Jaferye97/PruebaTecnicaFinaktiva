import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { Observable } from 'rxjs';

import { Customer } from '../interfaces/customersList';

@Injectable({
  providedIn: 'root',
})
export class CustomersListService {
  constructor(private http: HttpClient) {}

  GetAllCustomers(): Observable<Customer[]> {
    const urlConsulta = `${environment.urlInicial}${urlServices.customers}`;
    return this.http.get<Customer[]>(urlConsulta);
  }
}
