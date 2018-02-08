import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {residentRoutingComponents, ResidentRoutingModule} from './resident.routing.module';

import {SharedModule} from "../../shared/shared.module";
import {ResidentComponent} from "./resident.component";
import {ResidentPageComponent} from "./components/containers/resident-page/resident-page.component";
import {ResidentService} from "./services/resident.service";
import {ResidentCreateComponent} from "./components/containers/resident-create/resident-create.component";
import {TextMaskModule} from "angular2-text-mask";
import {ResidentEditFormComponent} from "./components/presentational/resident-edit-form/resident-edit-form.component";

@NgModule({
  declarations: [
    residentRoutingComponents
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ResidentRoutingModule,
    SharedModule,
    TextMaskModule
  ],
  providers: [
    ResidentService
  ],
  bootstrap: [
    ResidentComponent, ResidentPageComponent,
    ResidentCreateComponent, ResidentEditFormComponent
  ]
})
export class ResidentModule {
}
