import { Component, inject, Input, OnInit } from '@angular/core';
import { CarService } from '../../service/car';
import { Car } from '../../models/car.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view-car',
  imports: [CommonModule],
  templateUrl: './view-car.html',
  styleUrl: './view-car.css',
})
export class ViewCar implements OnInit {
  private carService = inject(CarService);
  @Input() idCar: string | null = null;
  car: Car | null = null;

  ngOnInit(): void {
    if (this.idCar) {
      this.carService.getCarById(this.idCar).subscribe({
        next: (car) => {
          this.car = car;
        },
        error: (error) => {
          console.error('Error fetching car details:', error);
        },
      });
    }
  }
}
