import { IDriver } from './../../models/driver/IDriver';
import { Injectable } from '@angular/core';
import { IRide } from '../../models/ride/IRide';
import { RideStatusEnum } from '../../enums/ride-status-enum';
import { CompanionService } from '../companion/companion.service';
import { DriverService } from '../driver/driver.service';

@Injectable({
  providedIn: 'root'
})
export class RideListService {

  constructor(private companionService: CompanionService, private driverService: DriverService) { }

  private rides: IRide[] = [
    {
      id: '1',
      from: 'Bucharest',
      to: 'Brasov',
      date: new Date('2019-02-01'),
      price: 100,
      status: RideStatusEnum.Pending,
      companionId: '',
      companion: this.companionService.getCompanions()[0],
      driverId: '',
      driver: this.driverService.getDrivers()[0],
    }
  ]

  getRides(): IRide[] {
    return this.rides;
  }
}
