import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { FacilityComponent } from './facility.component';
import { FacilityListComponent } from './components/presentational/facility-list/facility-list.component';
import {FacilityPageComponent} from './components/containers/facility-page/facility-page.component';
import {EditFacilityComponent} from './components/containers/edit-facility/edit-facility.component';
import {EditFacilityFormComponent} from './components/presentational/edit-facility-form/edit-facility-form.component';
import {FacilityDetailsComponent} from './components/containers/facility-details/facility-details.component';
import {FacilityDetailsIconsComponent} from './components/presentational/facility-details-icons/facility-details-icons.component';

export const routes: Routes = [
  {
    path: '',
    component: FacilityComponent,
    children: [
      {
        path: 'list',
        component: FacilityPageComponent
      },
      {
        path: 'create',
        component: EditFacilityComponent
      },
      {
        path: 'edit',
        component: EditFacilityComponent
      },
      {
        path: 'details',
        component: FacilityDetailsComponent
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class FacilityRoutingModule { }

export const routingComponents = [
  FacilityComponent,
  FacilityPageComponent,
  FacilityListComponent,
  EditFacilityComponent,
  EditFacilityFormComponent,
  FacilityDetailsComponent,
  FacilityDetailsIconsComponent
];
