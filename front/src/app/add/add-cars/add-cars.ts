import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  inject,
  Input,
  Output,
  SimpleChanges,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CarService } from '../../service/car';
import { Alert } from '../../service/alert';
import { Car } from '../../models/car.model';

@Component({
  selector: 'app-add-cars',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-cars.html',
  styleUrl: './add-cars.css',
})
export class AddCars {
  private carService = inject(CarService);
  private alertService = inject(Alert);
  @Output() carAdded = new EventEmitter<void>();
  @Input() carEditId: string | null = null;

  carForm = new FormGroup({
    brand: new FormControl('', [Validators.required]),
    model: new FormControl('', [Validators.required]),
    year: new FormControl('', [
      Validators.required,
      Validators.min(1886),
      Validators.max(new Date().getFullYear()),
    ]),
    plateNumber: new FormControl('', [Validators.required]),
    imageUrl: new FormControl('', [Validators.pattern('https?://.+')]),
    currentKm: new FormControl('', [Validators.required, Validators.min(0)]),
    isAvailable: new FormControl(true),
    doors: new FormControl(4, [Validators.min(2), Validators.max(5)]),
    capacity: new FormControl(5, [Validators.min(1), Validators.max(10)]),
    emissionClass: new FormControl('', []),
    fuelType: new FormControl('', []),
    transmission: new FormControl('', []),
    kmDay: new FormControl(0, [Validators.min(0)]),
    kmPenaltyFee: new FormControl(0, [Validators.min(0)]),
    dailyPrice: new FormControl(0, [Validators.required, Validators.min(0)]),
    dailyPenaltyFee: new FormControl(0, [Validators.min(0)]),
    unlimitedKmFee: new FormControl(0, [Validators.min(0)]),
  });

  addCars() {
    if (this.carForm.valid) {
      this.carService.createCar(this.carForm.value).subscribe({
        next: (response: any) => {
          this.alertService.showSuccess('Car added successfully');
          this.carAdded.emit();
        },
        error: (error: any) => {
          this.alertService.showError('Failed to add car. Please try again');
        },
      });
    } else {
      this.alertService.showError(
        'Please fill in all required fields correctly'
      );
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.carEditId) {
      this.carService.getCarById(this.carEditId).subscribe((car: Car) => {
        this.carForm.patchValue({
          brand: car.brand,
          model: car.model,
          year: car.year.toString(),
          currentKm: car.currentKm.toString(),
          plateNumber: car.plateNumber,
          imageUrl: car.imageUrl,
          isAvailable: car.isAvailable,
          doors: car.doors,
          capacity: car.capacity,
          emissionClass: car.emissionClass,
          fuelType: car.fuelType,
          transmission: car.transmission,
          kmDay: car.kmDay,
          kmPenaltyFee: car.kmPenaltyFee,
          dailyPrice: car.dailyPrice,
          dailyPenaltyFee: car.dailyPenaltyFee,
          unlimitedKmFee: car.unlimitedKmFee,
        });
      });
    } else {
      this.carEditId = '';
      this.carForm.reset();
    }
  }

  onClick() {
    if (this.carEditId) {
      this.updateCar();
    } else {
      this.addCars();
    }
  }
  updateCar() {
    if (this.carForm.valid) {
      this.carService.updateCar(this.carEditId!, this.carForm.value).subscribe({
        next: (response: any) => {
          this.alertService.showSuccess('Car updated successfully');
          this.carAdded.emit();
        },
        error: (error: any) => {
          this.alertService.showError('Failed to update car. Please try again');
        },
      });
    } else {
      this.alertService.showError(
        'Please fill in all required fields correctly'
      );
    }
  }
}
