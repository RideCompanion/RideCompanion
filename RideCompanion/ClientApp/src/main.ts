import {enableProdMode} from '@angular/core';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

import {environment} from './environments/environment';
import {RootModule} from './app/root/root.module';
import {RideService} from "./app/services/data-providers/ride/ride.service";

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [
  {provide: 'BASE_URL', useFactory: getBaseUrl, deps: []},
  {provide: RideService},
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(RootModule)
  .catch(err => console.log(err));
