import {Routes} from '@angular/router';
import {NotFoundComponent} from "./components/not-found/not-found.component";
import {HomeComponent} from "./components/home/home.component";
import {RideModule} from "./modules/ride/ride.module";
import {CompanionModule} from "./modules/companion/companion.module";
import {LoginComponent} from "./components/auth/login/login.component";
import {RegisterComponent} from "./components/auth/register/register.component";

export const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'ride', loadChildren: () => RideModule},
  {path: 'companion', loadChildren: () => CompanionModule},
  {path: '**', component: NotFoundComponent}
];
