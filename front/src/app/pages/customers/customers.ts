import { AfterViewInit, Component, inject, OnInit } from '@angular/core';
import { CustomerServce } from '../../service/customer';
import { CommonModule } from '@angular/common';
import { Customer } from '../../models/customer.models';
import { Modal } from 'bootstrap';
import { AddCustomers } from '../../add/add-customers/add-customers';
import { FormsModule } from '@angular/forms';
import { Alert } from '../../service/alert';

@Component({
  selector: 'app-customers',
  imports: [CommonModule, AddCustomers, FormsModule],
  templateUrl: './customers.html',
  styleUrl: './customers.css',
})
export class Customers implements OnInit, AfterViewInit {
  private alertService = inject(Alert);
  private customerService = inject(CustomerServce);

  totalPages: any;
  editCustomerSelected: any = null;
  paginatedCustomers: Customer[] = [];
  itemsPerPage: number = 8;
  currentPage: number = 1;
  customers: Customer[] = [];
  headers: string[] = [
    'Name',
    'Email',
    'Phone',
    'Address',
    'Document ID',
    'Actions',
  ];
  query: string = '';

  ngOnInit() {
    this.loadCustomers();
  }

  private loadCustomers() {
    this.customerService.getCustomers().subscribe((data) => {
      this.customers = data;
      this.totalPages = Math.ceil(this.customers.length / this.itemsPerPage);
      this.changePage(1);
    });
  }

  changePage(page: number) {
    this.currentPage = page;
    this.paginatedCustomers = this.customers.slice(
      (page - 1) * this.itemsPerPage,
      page * this.itemsPerPage
    );
  }
  deleteCustomer(idCustomer: string) {
    this.alertService
      .confirm('Are you sure you want to delete this customer?')
      .then((result) => {
        if (result) {
          this.customerService.deleteCustomer(idCustomer).subscribe(() => {
            this.loadCustomers();
          });
        }
      });
  }
  editCustomer(customer: any) {
    this.editCustomerSelected = customer.id;
    this.openModal(false);
  }

  searchCustomers(query: string) {
    if (!query) {
      this.loadCustomers();
      return;
    }
    var filteredCustomers = this.customers.filter((customer) => {
      return (
        customer.fullName.toLowerCase().includes(query.toLowerCase()) ||
        customer.email.toLowerCase().includes(query.toLowerCase()) ||
        customer.id.toString().includes(query)
      );
    });
    this.paginatedCustomers = filteredCustomers;
  }
  myModal: any;

  ngAfterViewInit() {
    const modalEl = document.getElementById('customerModal');
    if (modalEl) {
      this.myModal = new Modal(modalEl);
    }
  }

  openModal(create: boolean = true) {
    if (create) {
      this.editCustomerSelected = null;
    }
    this.myModal.show();
  }

  cerrarModal() {
    this.myModal.hide();
  }

  customerAdded() {
    this.loadCustomers();
    this.cerrarModal();
  }
}
