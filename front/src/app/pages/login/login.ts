import { Component, inject } from '@angular/core';
import { GoogleButton } from '../../components/google-button/google-button';
import { Auth } from '../../service/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [GoogleButton],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private authService = inject(Auth);
  private router = inject(Router);

  login() {
    this.authService.signInWithGoogle().then((token) => {
      if (token) {
        this.router.navigate(['/rentals']);
      }
    });
  }
}
