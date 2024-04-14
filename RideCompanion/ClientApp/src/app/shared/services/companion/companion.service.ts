import { Injectable } from '@angular/core';

export interface ICompanion {
  id: number;
  name: string;
  age: number;
}

@Injectable({
  providedIn: 'root'
})
export class CompanionService {
  constructor() { }

  private companionsList : ICompanion[] = [
    {
      id: 1,
      name: 'John',
      age: 30
    },
    {
      id: 2,
      name: 'Jane',
      age: 25
    }
  ];

  getCompanions(): ICompanion[] {
    return this.companionsList;
  }
}
