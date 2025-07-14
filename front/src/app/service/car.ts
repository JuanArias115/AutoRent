import { inject, Injectable } from '@angular/core';
import { environment } from '../enviroment';
import { Car } from '../models/car.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarService {
    private http = inject(HttpClient);
    private apiUrl = environment.apiUrl + 'Car';

    getCars() {
        return this.http.get<Car[]>(this.apiUrl);
    }

    getCarById(id: string) {
        return this.http.get<Car>(`${this.apiUrl}/${id}`);
    }

    createCar(car: any) {
        return this.http.post<Car>(this.apiUrl, car);
    }

    updateCar(id: string, car: any) {
        return this.http.put<Car>(`${this.apiUrl}/${id}`, car);
    }

    deleteCar(id: string) {
        return this.http.delete(`${this.apiUrl}/${id}`);
    }
}

  

