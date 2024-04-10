import { Routes } from '@angular/router';
import {NotFoundComponent} from "./components/not-found/not-found.component";
import {HomeComponent} from "./components/home/home.component";
import {RideModule} from "./modules/ride/ride.module";
import {CompanionModule} from "./modules/companion/companion.module";

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'ride',
    loadChildren: () => RideModule
  },
  {
    path: 'companion',
    loadChildren: () => CompanionModule
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];
