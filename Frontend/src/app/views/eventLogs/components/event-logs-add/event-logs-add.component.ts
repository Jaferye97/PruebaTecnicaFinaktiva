import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { NgFor } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';

import { EventLogsAddService } from '../../services/eventLogsAdd.service';
import { EventLog } from '../../interfaces/eventLogsAdd';

@Component({
  selector: 'app-event-logs-add',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatDialogModule,
    MatButtonModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    MatCardModule,
    CommonModule,
  ],
  templateUrl: './event-logs-add.component.html',
  styleUrls: ['./event-logs-add.component.css'],
})
export class EventLogsAddComponent implements OnInit {
  eventLogForm!: FormGroup;
  isLoadingSave: boolean = false;

  constructor(
    private fb: FormBuilder,
    private services: EventLogsAddService,
    private dialogRef: MatDialogRef<EventLogsAddComponent>
  ) {}

  ngOnInit(): void {
    this.eventLogForm = this.buildForm();
  }

  buildForm() {
    return this.fb.group({
      eventDate: [null, Validators.required],
      description: ['', [Validators.required, Validators.maxLength(255)]],
      exceptionMessage: [''],
    });
  }

  saveEventLog() {
    if (this.eventLogForm.invalid) return;

    this.isLoadingSave = true;
    const newEventLog = { EventType: 'FORM', ...this.eventLogForm.value };

    this.services.AddEventLogs(newEventLog).subscribe({
      next: (eventLogId) => {
        console.log('Event Log saved with ID:', eventLogId);
        this.dialogRef.close(true);
      },
      error: (err) => console.error('Error saving Event Log:', err),
    });
  }

  close() {
    this.dialogRef.close();
  }
}
