import {Component} from '@angular/core';
import {RideService} from "../../../../services/data-providers/ride/ride.service";

@Component({
  selector: 'app-companions',
  templateUrl: './companions.component.html',
  styleUrls: ['./companions.component.css']
})
export class CompanionsComponent {
  constructor(private rideService: RideService) {
  }

  public rides = this.rideService.getRides();
}
