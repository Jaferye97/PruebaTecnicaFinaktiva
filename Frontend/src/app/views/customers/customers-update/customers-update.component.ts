import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CommonModule, Location } from '@angular/common';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar } from '@angular/material/snack-bar';

import { finalize } from 'rxjs/internal/operators/finalize';

import { CustomersUpdateService } from '../services/customersUpdate.service';

import { isGuid } from '../../../../utils/validators.js';

@Component({
  selector: 'app-customers-update',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './customers-update.component.html',
  styleUrls: ['./customers-update.component.css'],
})
export class CustomersUpdateComponent implements OnInit {
  customerId: string = '';
  isLoadingPage: boolean = false;
  isLoadingSave: boolean = false;
  form: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private location: Location,
    private service: CustomersUpdateService,
    private snackBar: MatSnackBar
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  ngOnInit(): void {
    this.customerId = this.route.snapshot.paramMap.get('id')!;

    if (!isGuid(this.customerId)) {
      this.snackBar.open('Customer Id incorrect', 'Close', {
        duration: 3000,
        horizontalPosition: 'center',
        verticalPosition: 'top',
      });
      this.location.back();
    }
    this.getDataCustomer(this.customerId);
  }

  onBack(): void {
    this.location.back();
  }

  getDataCustomer(customerId: string): void {
    this.isLoadingPage = true;

    this.service
      .GetCustomer(customerId)
      .pipe(finalize(() => (this.isLoadingPage = false)))
      .subscribe({
        next: (customer) => {
          this.form.patchValue({
            name: customer.name,
            email: customer.email,
          });
        },
        error: (err) => console.error('Error fetching customer:', err),
      });
  }

  onSubmit(): void {
    if (this.form.invalid) return;

    this.isLoadingSave = true;
    const newCustomer = { id: this.customerId, ...this.form.value };

    this.service
      .UpdateCustomer(newCustomer)
      .pipe(finalize(() => (this.isLoadingSave = false)))
      .subscribe({
        next: (customer) => {
          console.log('Customer updated with ID:', customer.id);

          this.snackBar.open('Customer updated successfully ✅', 'Close', {
            duration: 3000,
            horizontalPosition: 'center',
            verticalPosition: 'top',
          });
          this.location.back();
        },
        error: (err) => console.error('Error updating customer:', err),
      });
  }
}
