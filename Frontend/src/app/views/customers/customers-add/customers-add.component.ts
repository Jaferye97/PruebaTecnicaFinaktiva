import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule, Location } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar } from '@angular/material/snack-bar';

import { CustomersAddService } from '../services/customersAdd.service';
import { finalize } from 'rxjs/internal/operators/finalize';

@Component({
  selector: 'app-customers-add',
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
  templateUrl: './customers-add.component.html',
  styleUrls: ['./customers-add.component.css'],
})
export class CustomersAddComponent {
  isLoadingSave: boolean = false;
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private location: Location,
    private service: CustomersAddService,
    private snackBar: MatSnackBar
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  onSubmit(): void {
    if (this.form.invalid) return;

    this.isLoadingSave = true;
    const newCustomer = this.form.value;

    this.service
      .AddCustomer(newCustomer)
      .pipe(finalize(() => (this.isLoadingSave = false)))
      .subscribe({
        next: (customer) => {
          console.log('Customer added with ID:', customer.id);

          this.snackBar.open('Customer saved successfully ✅', 'Close', {
            duration: 3000,
            horizontalPosition: 'center',
            verticalPosition: 'top',
          });
          this.location.back();
        },
        error: (err) => console.error('Error adding customer:', err),
      });
  }

  onBack(): void {
    this.location.back();
  }
}
