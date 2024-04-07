import {Component} from '@angular/core';
import {RideService} from "../../../../services/data-providers/ride/ride.service";

@Component({
  selector: 'app-rides',
  templateUrl: './rides.component.html',
  styleUrls: ['./rides.component.css']
})
export class RidesComponent {
  constructor(private rideService: RideService) {
  }

  public rides = this.rideService.getRides();
}
