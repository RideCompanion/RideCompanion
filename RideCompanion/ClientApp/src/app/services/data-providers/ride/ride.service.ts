import {Injectable} from '@angular/core';

export interface IRide {
  id: number;
  from: string;
  to: string;
  date: Date;
}

interface IRideService {
  getRides(): IRide[]
}

@Injectable({
  providedIn: 'root'
})
export class RideService {
  private rides: IRide[] = [
    {
      id: 1,
      from: 'London',
      to: 'Paris',
      date: new Date()
    },
    {
      id: 2,
      from: 'Paris',
      to: 'London',
      date: new Date()
    }
  ];

  getRides(): IRide[] {
    return this.rides;
  }
}
