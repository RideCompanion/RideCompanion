import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CompanionsListComponent} from "./components/companions-list/companions-list.component";
import {RouterModule} from "@angular/router";
import {OffcanvasComponent} from "../../components/offcanvas/offcanvas.component";

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        redirectTo: '/companion/list',
        pathMatch: 'full'
      },
      {
        path: 'list',
        component: CompanionsListComponent
      },
    ]),
    OffcanvasComponent
  ]
})
export class CompanionModule {
}
