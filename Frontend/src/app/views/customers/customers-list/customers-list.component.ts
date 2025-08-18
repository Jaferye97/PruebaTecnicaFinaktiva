import { Component, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';

import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup } from '@angular/forms';

import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

import { CustomersListService } from '../services/customersList.service';

import { Customer } from '../interfaces/customersList';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customers-list',
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
  ],
  templateUrl: './customers-list.component.html',
  styleUrl: './customers-list.component.css',
})
export class CustomersListComponent implements OnInit {
  loadingPage: boolean = false;
  displayedColumns: string[] = ['name', 'email', 'createdAt', 'actions'];
  dataSource: MatTableDataSource<Customer> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private router: Router,
    // private fb: FormBuilder,
    private service: CustomersListService // private dialog: MatDialog, // private snackBar: MatSnackBar
  ) {
    // this.form = this.fb.group({
    //   search: [''],
    // });
  }

  getDataCustomers(): void {
    this.loadingPage = true;

    this.service.GetAllCustomers().subscribe((data) => {
      this.dataSource.data = data;
      this.loadingPage = false;
    });
  }

  ngOnInit() {
    this.getDataCustomers();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  onAddCustomer() {
    this.router.navigate(['/customers/add']);
  }

  onEditCustomer(customer: Customer) {
    console.log('Editar cliente:', customer);
  }
}
