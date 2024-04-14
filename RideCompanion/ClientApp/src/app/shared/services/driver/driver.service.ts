import { Injectable } from '@angular/core';
import { IDriver } from '../../models/driver/IDriver';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  constructor() { }

  private driverList: IDriver[] = [
    {
      id: '1',
      firstname: 'John',
      lastname: 'Doe',
      birthdate: new Date('2019-02-01'),
      address: {
        zip: '12345',
        state: 'Bucharest',
        city: 'Bucharest',
        street: 'Bucharest'
      }
    }
  ]

  getDrivers(): IDriver[] {
    return this.driverList;
  }
}
