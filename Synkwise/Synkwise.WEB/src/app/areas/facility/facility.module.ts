import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FacilityComponent } from './facility.component';
import { routingComponents, FacilityRoutingModule } from './facility.routing.module';

import { SharedModule } from "../../shared/shared.module";
import {HttpModule} from "@angular/http";
import {FacilityService} from "./services/facility.service/facility.service";

@NgModule({
  declarations: [
    routingComponents
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    FacilityRoutingModule,
    SharedModule,
    HttpModule
  ],
  providers: [
    FacilityService
  ],
  bootstrap: [
    FacilityComponent
  ]
})
export class FacilityModule { }
