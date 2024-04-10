import { Component } from '@angular/core';
import {RideRouteComponent} from "../ride-route/ride-route.component";

@Component({
  selector: 'app-my-rides',
  standalone: true,
  imports: [RideRouteComponent],
  templateUrl: './my-rides.component.html',
  styleUrl: './my-rides.component.scss'
})
export class MyRidesComponent {

}
