import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {RidesListComponent} from "./components/rides-list/rides-list.component";
import {MyRidesComponent} from "./components/my-rides/my-rides.component";
import {RideRouteComponent} from "./components/ride-route/ride-route.component";

@NgModule({
  declarations: [],
  exports: [],
  imports: [
    CommonModule,
    RideRouteComponent,
    RouterModule.forChild([
      {
        path: '',
        redirectTo: '/ride/list',
        pathMatch: 'full'
      },
      { path: 'list', component: RidesListComponent },
      { path: 'my', component: MyRidesComponent },
    ])
  ]
})
export class RideModule {
}
