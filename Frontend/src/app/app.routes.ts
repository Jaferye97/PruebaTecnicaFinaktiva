import { Routes } from '@angular/router';
import { CustomersRoutes } from './views/customers/customers.routes';
import { EventLogsRoutes } from './views/eventLogs/eventLogs.routes';

export const routes: Routes = [
  ...CustomersRoutes,
  ...EventLogsRoutes,
  { path: '**', redirectTo: '' },
];
