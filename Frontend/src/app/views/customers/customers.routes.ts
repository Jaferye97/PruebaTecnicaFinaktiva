import { Routes } from '@angular/router';
import { CustomersListComponent } from './customers-list/customers-list.component';

export const CustomersRoutes: Routes = [
  {
    path: 'customers',
    children: [{ path: '', component: CustomersListComponent }],
  },
];
