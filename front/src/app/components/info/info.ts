import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-info',
  imports: [CommonModule],
  templateUrl: './info.html',
  styleUrl: './info.css'
})
export class Info {

@Input() totalCarsCount: any = "0";
@Input() totalRentalsCount: any = "0";



}
