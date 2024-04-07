import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {RootComponent} from "./root.component";
import {NavMenuComponent} from "../shared/components/nav-menu/nav-menu.component";
import {HomeComponent} from "../modules/home/components/home/home.component";
import {CounterComponent} from "../shared/components/counter/counter.component";
import {FetchDataComponent} from "../shared/components/fetch-data/fetch-data.component";
import {CompanionModule} from "../modules/companion/companion.module";
import {DriverModule} from "../modules/driver/driver.module";
import {NotFoundComponent} from "../shared/components/not-found/not-found.component";
import {RideModule} from "../modules/ride/ride.module";

@NgModule({
  declarations: [
    RootComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'counter', component: CounterComponent},
      {path: 'fetch-data', component: FetchDataComponent},
      {path: 'ride', loadChildren: () => RideModule},
      {path: 'companion', loadChildren: () => CompanionModule},
      {path: 'driver', loadChildren: () => DriverModule},
      {path: '**', component: NotFoundComponent},
    ])
  ],
  providers: [],
  bootstrap: [RootComponent]
})
export class RootModule {
}
