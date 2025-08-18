import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { EventLogsListService } from '../services/eventLogsList.service';

import { EventLog } from '../interfaces/eventLogsList';

@Component({
  selector: 'app-event-logs-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './event-logs-list.component.html',
  styleUrls: ['./event-logs-list.component.css'],
})
export class EventLogsListComponent implements OnInit, AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  loadingPage: boolean = false;
  displayedColumns: string[] = [
    'eventDate',
    'description',
    'eventType',
    'referenceEntity',
    'referenceId',
    'createdAt',
  ];
  dataSource: MatTableDataSource<EventLog> = new MatTableDataSource();

  constructor(private router: Router, private service: EventLogsListService) {}

  getDataCustomers(): void {
    this.loadingPage = true;

    this.service.GetAllEventLogs().subscribe((data) => {
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

  onAddEventLog() {
    console.log('Adding new event log');
    // this.router.navigate(['/event-logs/add']);
  }
}
