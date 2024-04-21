import { Injectable } from '@angular/core';
import { ICompanion } from '../../models/copanion/ICompanion';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CompanionProvider {
  constructor(private http: HttpClient) {}

  private companionsList: ICompanion[] = [];

  configUrl = 'https://jsonplaceholder.typicode.com/users';

  private loadCompanions() {
    this.http.get<ICompanion[]>(this.configUrl).subscribe(
      (data) =>
        (this.companionsList = {
          ...data,
        })
    );
  }

  getCompanions(): ICompanion[] {
    return this.companionsList;
  }
}
