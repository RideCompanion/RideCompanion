import { Routes } from '@angular/router';
import {HomeModule} from "./modules/home/home.module";
import {NotFoundComponent} from "./components/not-found/not-found.component";

export const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => HomeModule
  },
  {
    path: 'ride',
    loadChildren: () => import('./modules/ride/ride.module').then(m => m.RideModule)
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];
