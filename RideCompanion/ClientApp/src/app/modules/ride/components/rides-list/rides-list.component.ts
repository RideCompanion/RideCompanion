import { Component, OnInit } from '@angular/core';
import {RideRouteComponent} from "../ride-route/ride-route.component";
import {RideListService} from "../../../../services/data-providers/ride/ride-list.service";

@Component({
  selector: 'app-rides-list',
  standalone: true,
  imports: [RideRouteComponent],
  templateUrl: './rides-list.component.html',
  styleUrl: './rides-list.component.scss'
})
export class RidesListComponent {
  constructor(private _rideListService: RideListService) {
  }

  protected ridesList = this._rideListService.getRides();
}
