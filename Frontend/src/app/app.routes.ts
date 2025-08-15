import { Routes } from '@angular/router';
import { CustomersRoutes } from './views/customers/customers.routes';

export const routes: Routes = [
  ...CustomersRoutes,
  { path: '**', redirectTo: '' },
];
