import { Component, inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Auth } from '../../service/auth';

@Component({
  selector: 'app-side-menu',
  imports: [RouterModule],
  templateUrl: './side-menu.html',
  styleUrl: './side-menu.css',
})
export class SideMenu implements OnInit {
  private authServe = inject(Auth);
  nameUser: string = '';

  ngOnInit() {
    try {
      const user = this.authServe.getCurrentUser();
      this.nameUser =
        user && user.displayName?.split(' ')[0]
          ? user.displayName?.split(' ')[0]
          : 'User';
    } catch (error: any) {
      console.error('Error fetching user data:', error);
      this.nameUser = 'User';
    }
  }

  async logOut() {
    await this.authServe.logOut();
    localStorage.removeItem('token');
    window.location.reload();
  }
}
