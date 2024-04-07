import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CompanionsComponent} from './components/companions/companions.component';
import {CompanionRoutingModule} from "./companion.routing.module";

@NgModule({
  declarations: [
    CompanionsComponent
  ],
  imports: [
    CommonModule,
    CompanionRoutingModule
  ]
})
export class CompanionModule {
}
