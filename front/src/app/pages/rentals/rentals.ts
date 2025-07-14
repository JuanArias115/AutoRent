import { Component, inject, OnInit } from '@angular/core';
import { Rental } from '../../service/rental';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Info } from '../../components/info/info';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ReturnCar } from '../../components/return-car/return-car';
import { Alert } from '../../service/alert';
import { ViewRent } from '../../components/view-rent/view-rent';

@Component({
  selector: 'app-rentals',
  imports: [FormsModule, CommonModule, Info, ReturnCar, ViewRent],
  templateUrl: './rentals.html',
  styleUrl: './rentals.css',
})
export class Rentals implements OnInit {
  private alertService = inject(Alert);
  showAvailableCars: boolean = false;
  private modalService = inject(NgbModal);
  private rentalService = inject(Rental);
  rentalList: any[] = [];
  headers: string[] = [
    'Car',
    'Start',
    'Expected',
    'Start Km',
    'Expected Km',
    'Unlimited',
    'Status',
    'Actions',
  ];
  rentalSelected: any = null;
  rentalPaginated: any[] = [];
  page: number = 1;
  pageSize: number = 10;
  currentPage: number = 1;
  totalPages: number = 0;

  rentalCount: number = 0;
  totalRevenue: number = 0;

  ngOnInit() {
    this.loadRentals();
  }

  cancelRental(id: string) {
    this.alertService
      .confirm('Are you sure you want to cancel this rental?')
      .then((confirmed) => {
        if (confirmed) {
          this.rentalService.deleteRental(id).subscribe({
            next: () => {
              this.loadRentals();
              this.infoData();
            },
            error: (error) => {
              console.error('Error canceling rental:', error);
            },
          });
        }
      });
  }

  infoData() {
    this.rentalService.getRentals().subscribe((data) => {
      this.rentalCount = data.length;
      this.totalRevenue = data.reduce(
        (sum, rental) => sum + (rental.endKm - rental.startKm) * 0.5,
        0
      );
    });
  }

  private loadRentals() {
    this.showAvailableCars = false;
    this.rentalService.getRentals().subscribe((data) => {
      this.rentalList = data;
      this.dataInfo();
      this.totalPages = Math.ceil(this.rentalList.length / this.pageSize);
      this.changePage(1);
    });
  }

  openModal(type: string, content: any, rental: any) {
    if (type === 'return') {
      this.rentalSelected = { ...rental };
    } else if (type === 'view') {
      this.rentalSelected = { ...rental };
    }
    this.modalService.open(content, { centered: true, size: 'lg' });
  }

  rentalModified() {
    this.loadRentals();
    this.modalService.dismissAll();
  }

  dataInfo() {
    this.totalRevenue = 0;
    this.rentalList.forEach((rental) => {
      this.totalRevenue += rental.totalPaid || 0;
    });

    this.rentalCount = this.rentalList.filter(
      (rental) => rental.status === 'active'
    ).length;
  }

  changePage(page: number) {
    this.currentPage = page;
    this.rentalPaginated = this.rentalList.slice(
      (page - 1) * this.pageSize,
      page * this.pageSize
    );
    this.page = page;
  }

  toggleAvailability() {
    this.showAvailableCars = !this.showAvailableCars;
    if (this.showAvailableCars) {
      this.rentalList = this.rentalList.filter(
        (rental) => rental.status === 'active'
      );
      this.rentalPaginated = this.rentalList.slice(0, this.pageSize);
      this.totalPages = Math.ceil(this.rentalList.length / this.pageSize);
    } else {
      this.loadRentals();
    }
  }
}
