import { CommonModule } from '@angular/common';
import {
  Component,
  OnChanges,
  EventEmitter,
  inject,
  Input,
  OnInit,
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
import { Rental } from '../../service/rental';
import { Alert } from '../../service/alert';

@Component({
  selector: 'app-return-car',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './return-car.html',
  styleUrl: './return-car.css',
})
export class ReturnCar implements OnChanges {
  ngOnChanges(changes: SimpleChanges): void {
    this.loadCar();
  }
  private carService = inject(CarService);
  private rentalService = inject(Rental);
  private alertService = inject(Alert);

  @Input() rental: any | null = null;
  @Output() rentalReturned = new EventEmitter<void>();

  today = new Date().toISOString().split('T')[0];
  checkOut: any;
  minKm: number = 0;
  total: number = 0;

  orderInfo: any = {
    carName: '',
    days: 0,
    rentCost: 0,
    lateReturnFee: 0,
    excessKmFee: 0,
    damageCost: 0,
  };

  rentalForm: any = new FormGroup({
    actualReturn: new FormControl('', Validators.required),
    endKm: new FormControl('', Validators.required),
    damageCost: new FormControl(0, Validators.required),
  });

  onSubmit() {
    if (this.rentalForm.valid) {
      this.rentalService
        .returnRental(this.rental.id, {
          returnKm: this.rentalForm.get('endKm')?.value,
          actualReturn: this.rentalForm.get('actualReturn')?.value,
          totalPaid: this.total,
        })
        .subscribe({
          next: (response: any) => {
            this.alertService.showSuccess('Rental returned successfully');
            this.rentalReturned.emit();
          },
          error: (error: any) => {
            console.error('Error returning rental:', error);
            this.alertService.showError(
              'Failed to return rental. Please try again'
            );
          },
        });
    }
  }
  calculateOrderInfo() {
    this.rentalService
      .checkOut(this.rental.id, this.rentalForm.get('endKm')?.value, new Date())
      .subscribe(
        (data: any) => {
          this.orderInfo.damageCost =
            this.rentalForm.get('damageCost')?.value || 0;
          this.orderInfo = {
            ...this.orderInfo,
            carName: data.car,
            days: data.rentalDuration,
            rentCost: data.rentCost,
            lateReturnFee: data.lateReturnFee,
            excessKmFee: data.excessKmFee,
          };

          this.total =
            this.orderInfo.rentCost +
            this.orderInfo.lateReturnFee +
            this.orderInfo.excessKmFee +
            this.rentalForm.get('damageCost')?.value;
        },
        (error: any) => {
          console.error('Error calculating order info:', error);
        }
      );
  }

  loadCar() {
    if (this.rental.carId) {
      this.carService.getCarById(this.rental.carId).subscribe((car) => {
        this.rental.carId = car.id;
        this.orderInfo.carName = `${car.brand} ${car.model}`;
        this.orderInfo.dailyPrice = car.dailyPrice;
        this.rentalForm.patchValue({
          endKm: car.currentKm,
          actualReturn: this.today,
        });
        this.minKm = car.currentKm;
        this.calculateOrderInfo();
      });
    }
  }
}
