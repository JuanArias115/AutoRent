import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Rentals } from './pages/rentals/rentals';
import { authGuard } from './guards/auth-guard';
import { Cars } from './pages/cars/cars';
import { Customers } from './pages/customers/customers';
import { Main } from './pages/main/main';

export const routes: Routes = [
    {path: '', component: Login},
    {path: 'login', component: Login},
    {
        path: '',
        component: Main,
        canActivate: [authGuard],
        children: [
            {path : 'rentals', component: Rentals, canActivate: [authGuard]},
            {path : 'cars', component: Cars, canActivate: [authGuard]},
            {path : 'customers', component: Customers, canActivate: [authGuard]}
        ]
    },  
];
