import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./Pages/authentic/authentic.component').then(m => m.AuthenticComponent),
  },
  {
     path: 'Home',
    loadComponent: () =>
      import('./Pages/home/home.component').then(m => m.HomeComponent),
  }
];
