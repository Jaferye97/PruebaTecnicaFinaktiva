import { Routes } from '@angular/router';
import { EventLogsListComponent } from './event-logs-list/event-logs-list.component';

export const EventLogsRoutes: Routes = [
  {
    path: 'eventLogs',
    children: [{ path: '', component: EventLogsListComponent }],
  },
];
