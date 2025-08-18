import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

import { CustomersListService } from '../services/customersList.service';

import { Customer } from '../interfaces/customersList';

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

  constructor(private router: Router, private service: CustomersListService) {}

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
    this.router.navigate(['/customers/edit', customer.id]);
  }
}
