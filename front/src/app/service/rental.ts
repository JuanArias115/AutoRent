import { Injectable } from '@angular/core';
import { inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../enviroment';

@Injectable({
  providedIn: 'root',
})
export class Rental {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl + 'Rental';

  getRentals() {
    return this.http.get<any[]>(this.apiUrl);
  }

  getRentalById(id: string) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
  createRental(rental: any) {
    return this.http.post<any>(this.apiUrl, rental);
  }

  returnRental(id: string, rental: any) {
    return this.http.put<any>(`${this.apiUrl}/${id}`, rental);
  }

  deleteRental(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  checkOut(id: string, km: number, checkOutDate: Date) {
    const body = {
      actualKm: km,
      actualDate: checkOutDate,
    };

    return this.http.post<any>(`${this.apiUrl}/${id}/checkOut`, body);
  }
}
