import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {RidesComponent} from "./components/rides/rides.component";
import {MyRidesComponent} from "./components/my-rides/my-rides.component";

const routes: Routes = [
  {
    path: '',
    component: RidesComponent
  },
  {
    path: 'my-ride',
    component: MyRidesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RidesRoutingModule {
}
