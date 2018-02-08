import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {ManagementComponent} from './management.component';
import {routingComponents, ManagementRoutingModule} from './management.routing.module';

import {SharedModule} from "../../shared/shared.module";
import {HttpModule} from "@angular/http";
import {ManagementService} from "./services/management.service/management.service";

@NgModule({
  declarations: [
    routingComponents
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ManagementRoutingModule,
    SharedModule,
    HttpModule
  ],
  providers: [
    ManagementService
  ],
  bootstrap: [
    ManagementComponent
  ]
})
export class ManagementModule {
}
