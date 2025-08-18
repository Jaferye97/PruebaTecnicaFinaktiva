import { Routes } from '@angular/router';
import { CustomersListComponent } from './customers-list/customers-list.component';
import { CustomersAddComponent } from './customers-add/customers-add.component';

export const CustomersRoutes: Routes = [
  {
    path: 'customers',
    children: [
      { path: '', component: CustomersListComponent },
      { path: 'add', component: CustomersAddComponent },
    ],
  },
];
