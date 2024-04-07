import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {CompanionsComponent} from "./components/companions/companions.component";

const routes: Routes = [
  {
    path: '',
    component: CompanionsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanionRoutingModule {
}
