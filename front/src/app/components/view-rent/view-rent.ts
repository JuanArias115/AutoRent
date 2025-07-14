import { Component, inject, Input, OnInit } from '@angular/core';
import { Rental } from '../../service/rental';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view-rent',
  imports: [CommonModule],
  templateUrl: './view-rent.html',
  styleUrl: './view-rent.css'
})
export class ViewRent implements OnInit {

  @Input() rentalId: string = '';

  private rentService = inject(Rental);

  rental: any = {};

  ngOnInit(): void {
    this.rentService.getRentalById(this.rentalId).subscribe(data => {
      this.rental = data;
    });
  }


}
