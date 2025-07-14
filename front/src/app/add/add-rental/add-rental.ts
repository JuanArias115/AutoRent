import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  inject,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CarService } from '../../service/car';
import { CustomerServce } from '../../service/customer';
import { Rental } from '../../service/rental';
import { Car } from '../../models/car.model';
import { Alert } from '../../service/alert';

@Component({
  selector: 'app-add-rental',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-rental.html',
  styleUrl: './add-rental.css',
})
export class AddRental implements OnInit {
  @Input() idCar: string | null = null;
  @Output() rentalCreated = new EventEmitter<void>();

  private readonly carService = inject(CarService);
  private readonly userService = inject(CustomerServce);
  private readonly rentalService = inject(Rental);
  private readonly alertService = inject(Alert);
  today: string = new Date().toISOString().split('T')[0];
  userList: any;
  car: Car | null = null;
  orderInfo: any = {
    carName: '',
    days: 0,
    dailyPrice: 0,
    totalPrice: 0,
    isUnlimitedKm: false,
  };

  ngOnInit() {
    this.loadUsers();
    this.loadCar();
  }

  calculateOrderInfo() {
    const { startDate, expectedDate } = this.rentalForm.value;
    const start = new Date(startDate);
    const end = new Date(expectedDate);
    const timeDiff = end.getTime() - start.getTime();
    let days = Math.ceil(timeDiff / (1000 * 3600 * 24));

    if (days <= 0 || days === undefined) days = 1;
    console.log('Days:', days);
    this.orderInfo = {
      carName: this.car?.brand + ' ' + this.car?.model,
      days: days,
      dailyPrice: this.car?.dailyPrice,
      totalPrice: days * this.car?.dailyPrice!,
    };
  }

  loadUsers() {
    this.userService.getCustomers().subscribe({
      next: (users) => {
        this.userList = users;
        this.rentalForm.patchValue({
          customerId: this.userList.length > 0 ? this.userList[0].id : '',
          startDate: new Date().toISOString().split('T')[0],
          expectedDate: new Date(new Date().setDate(new Date().getDate() + 1))
            .toISOString()
            .split('T')[0],
        });
      },
      error: (err) => {
        console.error('Error loading users:', err);
      },
    });
  }

  loadCar() {
    if (this.idCar) {
      this.carService.getCarById(this.idCar).subscribe({
        next: (car) => {
          this.car = car;
          this.calculateOrderInfo();

          this.rentalForm.patchValue({
            carId: this.idCar,
            startDate: new Date().toISOString().split('T')[0],
            expectedDate: new Date(new Date().setDate(new Date().getDate() + 1))
              .toISOString()
              .split('T')[0],
          });
        },
        error: (err) => {
          console.error('Error loading car:', err);
        },
      });
    }
  }

  onSubmit() {
    this.rentalService
      .createRental({
        carId: this.idCar,
        ...this.rentalForm.value,
      })
      .subscribe({
        next: (response) => {
          this.alertService.showSuccess('Rental created successfully');
          this.rentalForm.reset();
          this.rentalCreated.emit();
        },
        error: (error) => {
          this.alertService.showError(
            'Failed to create rental. Please try again'
          );
          console.error('Error creating rental:', error);
        },
      });
  }

  rentalForm: FormGroup = new FormGroup({
    startDate: new FormControl('', [Validators.required]),
    expectedDate: new FormControl('', [Validators.required]),
    customerId: new FormControl('', [Validators.required]),
    isUnlimitedKm: new FormControl(false),
  });
}
