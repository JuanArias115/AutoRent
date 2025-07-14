import {
  Component,
  EventEmitter,
  inject,
  Input,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { CustomerServce } from '../../service/customer';
import { Alert } from '../../service/alert';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-add-customers',
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './add-customers.html',
  styleUrl: './add-customers.css',
})
export class AddCustomers {
  private customerService = inject(CustomerServce);
  private alertService = inject(Alert);
  @Output() customerAdded = new EventEmitter<void>();
  @Input() customerEditId: string = '';

  customerEdit: any = null;

  customerForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phone: new FormControl('', [
      Validators.required,
      Validators.pattern('^[0-9]+$'),
    ]),
    address: new FormControl('', [Validators.required]),
    documentId: new FormControl('', [Validators.required]),
  });

  onclick() {
    if (this.customerEdit) {
      this.updateCustomer();
    } else {
      this.addCustomer();
    }
  }

  addCustomer() {
    this.closeModal();
    if (this.customerForm.valid) {
      this.customerService.createCustomer(this.customerForm.value).subscribe({
        next: (response: any) => {
          this.alertService.showSuccess('Customer added successfully');
          this.customerAdded.emit();
        },
        error: (error: any) => {
          this.alertService.showError(
            'Failed to add customer. Please try again'
          );
        },
      });
    } else {
      this.alertService.showError(
        'Please fill in all required fields correctly'
      );
    }
  }

  updateCustomer() {
    this.closeModal();
    if (this.customerForm.valid) {
      const updatedCustomer = {
        ...this.customerForm.value,
      };

      this.customerService
        .updateCustomer(this.customerEditId, updatedCustomer)
        .subscribe({
          next: (response: any) => {
            this.alertService.showSuccess('Customer updated successfully');
            this.customerAdded.emit();
          },
          error: (error: any) => {
            this.alertService.showError(
              'Failed to update customer. Please try again'
            );
          },
        });
    } else {
      this.alertService.showError(
        'Please fill in all required fields correctly'
      );
    }
  }

  closeModal() {
    const modalElement = document.getElementById('exampleModal');
    if (modalElement) {
      const modal = Modal.getInstance(modalElement);
      if (modal) {
        modal.hide();
      }
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.customerEditId) {
      this.customerService
        .getCustomerById(this.customerEditId)
        .subscribe((customer) => {
          this.customerEdit = customer;
          this.customerForm.patchValue(customer);
        });
    } else {
      this.customerEdit = null;
      this.customerForm.reset();
    }
  }
}
