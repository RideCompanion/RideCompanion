import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RidesComponent } from './components/rides/rides.component';
import {RidesRoutingModule} from "./ride.routing.module";
import {MyRidesComponent} from "./components/my-rides/my-rides.component";

@NgModule({
  declarations: [
    RidesComponent,
    MyRidesComponent
  ],
  imports: [
    CommonModule,
    RidesRoutingModule
  ]
})
export class RideModule { }
