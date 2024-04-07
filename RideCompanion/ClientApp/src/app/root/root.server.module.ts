import {NgModule} from '@angular/core';
import {ServerModule} from '@angular/platform-server';
import {RootModule} from './root.module';
import {RootComponent} from './root.component';

@NgModule({
  imports: [RootModule, ServerModule],
  bootstrap: [RootComponent],
})
export class AppServerModule {
}
