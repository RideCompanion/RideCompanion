import { Injectable } from '@angular/core';
import { ICompanion } from '../../models/copanion/ICompanion';

@Injectable({
  providedIn: 'root',
})
export class CompanionService {
  constructor() {}

  private companionsList: ICompanion[] = [
    {
      id: '1',
      name: 'Leanne Graham',
      username: 'Bret',
      email: 'Sincere@april.biz',
      birthDate: new Date('01.01.1990'),
      address: {
        street: 'Kulas Light',
        suite: 'Apt. 556',
        city: 'Gwenborough',
        zipcode: '92998-3874',
        geo: {
          lat: '-37.3159',
          lng: '81.1496',
        },
      },
      phone: '1-770-736-8031 x56442',
      website: 'hildegard.org',
    },
    {
      id: '2',
      name: 'Ervin Howell',
      username: 'Antonette',
      email: 'Shanna@melissa.tv',
      birthDate: new Date('01.01.1990'),
      address: {
        street: 'Victor Plains',
        suite: 'Suite 879',
        city: 'Wisokyburgh',
        zipcode: '90566-7771',
        geo: {
          lat: '-43.9509',
          lng: '-34.4618',
        },
      },
      phone: '010-692-6593 x09125',
      website: 'anastasia.net',
    },
  ];

  getCompanions(): ICompanion[] {
    return this.companionsList;
  }
}
