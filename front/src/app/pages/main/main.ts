import { Component } from '@angular/core';
import { Navbar } from '../../components/navbar/navbar';
import { RouterOutlet } from '@angular/router';
import { SideMenu } from '../../components/side-menu/side-menu';
import { NgxSpinnerModule } from 'ngx-spinner';

@Component({
  selector: 'app-main',
  imports: [RouterOutlet, SideMenu, NgxSpinnerModule],
  templateUrl: './main.html',
  styleUrl: './main.css',
})
export class Main {}
