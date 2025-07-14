import { Component, inject, OnInit } from '@angular/core';
import { CarService } from '../../service/car';
import { Car } from '../../models/car.model';
import { CommonModule } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddCars } from '../../add/add-cars/add-cars';
import { ViewCar } from '../../components/view-car/view-car';
import { AddRental } from '../../add/add-rental/add-rental';
import { Alert } from '../../service/alert';

@Component({
  selector: 'app-cars',
  imports: [CommonModule, AddCars, ViewCar, AddRental],
  templateUrl: './cars.html',
  styleUrl: './cars.css',
})
export class Cars implements OnInit {
  private modalService = inject(NgbModal);
  private carService = inject(CarService);
  private alertService = inject(Alert);

  cars: Car[] = [];
  headers: string[] = [
    'Brand',
    'Model',
    'Year',
    'Current Km',
    'Plate Number',
    'Is Available',
    'Actions',
  ];
  query: string = '';
  currentPage: number = 1;
  totalPages: number = 0;
  itemsPerPage: number = 8;
  totalItems: number = 0;
  editCarSelected: any;
  selectedCarViewId: string | null = null;
  paginatedCars: Car[] = [];
  showAvailableCars: boolean = false;

  ngOnInit() {
    this.loadCars();
  }

  private loadCars() {
    this.carService.getCars().subscribe((data) => {
      this.cars = data;
      this.totalItems = this.cars.length;
      this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
      this.changePage(1);
    });
  }

  searchCars(query: string) {
    if (!query) {
      this.loadCars();
      return;
    }

    this.paginatedCars = this.cars.filter((car) => {
      return (
        car.brand.toLowerCase().includes(query.toLowerCase()) ||
        car.model.toLowerCase().includes(query.toLowerCase())
      );
    });
  }

  toggleAvailability() {
    this.showAvailableCars = !this.showAvailableCars;

    if (!this.showAvailableCars) {
      this.loadCars();
    } else {
      this.cars = this.cars.filter((car) => car.isAvailable);
      this.totalItems = this.cars.length;
      this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
      this.changePage(1);
    }
  }

  deleteCar(carId: string) {
    this.alertService
      .confirm('Are you sure you want to delete this car?')
      .then((confirmed) => {
        if (confirmed) {
          this.carService.deleteCar(carId).subscribe(() => {
            this.loadCars();
          });
        }
      });
  }

  changePage(page: number) {
    this.paginatedCars = this.cars.slice(
      (page - 1) * this.itemsPerPage,
      page * this.itemsPerPage
    );
    this.currentPage = page;
  }

  openModal(type: string, content: any, carId: string | null = null) {
    switch (type) {
      case 'create':
        this.editCarSelected = null;
        this.modalService.open(content, {
          size: 'xl',
        });
        break;
      case 'edit':
        this.editCarSelected = carId;
        this.modalService.open(content, {
          size: 'lg',
        });
        break;
      case 'view':
        this.selectedCarViewId = carId;
        this.modalService.open(content, {
          size: 'lg',
        });
        break;
      case 'rental':
        this.selectedCarViewId = carId;
        this.modalService.open(content, {
          size: 'xl',
        });
        break;
      default:
    }
  }

  carModified() {
    this.loadCars();
    this.modalService.dismissAll();
  }
}
