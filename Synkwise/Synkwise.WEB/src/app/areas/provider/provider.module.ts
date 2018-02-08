import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpModule} from "@angular/http";
import {ProviderComponent} from './provider.component';
import {routingComponents, ProviderRoutingModule} from './provider.routing.module';

import { SharedModule } from '../../shared/shared.module';
import {ProviderService} from './services/provider.service/provider.service';

@NgModule({
  declarations: [
    routingComponents
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpModule,
    ProviderRoutingModule,
    SharedModule
  ],
  providers: [
    ProviderService
  ],
  bootstrap: [
    ProviderComponent
  ]
})
export class ProviderModule {
}
