import { Routes } from '@angular/router';
import { CustomersListComponent } from './customers-list/customers-list.component';
import { CustomersAddComponent } from './customers-add/customers-add.component';
import { CustomersUpdateComponent } from './customers-update/customers-update.component';

export const CustomersRoutes: Routes = [
  {
    path: 'customers',
    children: [
      { path: '', component: CustomersListComponent },
      { path: 'add', component: CustomersAddComponent },
      { path: 'edit/:id', component: CustomersUpdateComponent },
    ],
  },
];
