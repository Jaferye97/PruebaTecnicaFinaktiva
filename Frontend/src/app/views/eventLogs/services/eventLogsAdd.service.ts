import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { Observable } from 'rxjs';

import { EventLog } from '../interfaces/eventLogsList';

@Injectable({
  providedIn: 'root',
})
export class EventLogsAddService {
  constructor(private http: HttpClient) {}

  AddEventLogs(eventLog: EventLog): Observable<EventLog> {
    const urlConsulta = `${environment.urlInicial}${urlServices.eventLogs}`;
    return this.http.post<EventLog>(urlConsulta, eventLog);
  }
}
