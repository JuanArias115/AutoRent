import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-google-button',
  imports: [],
  templateUrl: './google-button.html',
  styleUrl: './google-button.css',
})
export class GoogleButton {
  @Input() login!: () => void;

  onClick() {
    if (this.login) {
      this.login();
    }
  }
}
