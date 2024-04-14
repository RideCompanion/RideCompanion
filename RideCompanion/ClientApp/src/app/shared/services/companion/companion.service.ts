import { Injectable } from '@angular/core';
import { ICompanion } from '../../models/copanion/ICompanion';

@Injectable({
  providedIn: 'root'
})
export class CompanionService {

  constructor() { }

  private companionsList : ICompanion[] = [
    {
      id: '1',
      firstName: 'John',
      lastName: 'Doe',
      birthDate: new Date('2019-02-01'),
      address: {
        zip: '12345',
        state: 'Bucharest',
        city: 'Bucharest',
        street: 'Bucharest'
      }
    }
  ];

  getCompanions(): ICompanion[] {
    return this.companionsList;
  }
}
