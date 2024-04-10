import { Injectable } from '@angular/core';

export interface IRide {
  id: number;
  from: string;
  to: string;
  date: Date;
  price: number;
}

@Injectable({
  providedIn: 'root'
})
export class RideListService {

  constructor() { }

  private rides: IRide[] = [
    {
      id: 1,
      from: 'Bucharest',
      to: 'Pitesti',
      date: new Date('2019-02-01'),
      price: 100
    },
    {
      id: 2,
      from: 'Bucharest',
      to: 'Sibiu',
      date: new Date('2019-02-15'),
      price: 200
    }]

  getRides(): IRide[] {
    return this.rides;
  }
}
