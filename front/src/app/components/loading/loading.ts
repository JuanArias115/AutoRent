import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { LoadingService } from '../../service/loading';

@Component({
  selector: 'app-loading',
  imports: [CommonModule],
  templateUrl: './loading.html',
  styleUrl: './loading.css',
})
export class Loading {
  public loadingService = inject(LoadingService);
}
