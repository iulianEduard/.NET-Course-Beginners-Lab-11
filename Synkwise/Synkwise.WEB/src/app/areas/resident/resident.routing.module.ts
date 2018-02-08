import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';

import {ResidentComponent} from "./resident.component";
import {ResidentPageComponent} from "./components/containers/resident-page/resident-page.component";
import {ResidentHomeComponent} from "./components/presentational/resident-home/resident-home.component";
import {ResidentDetailComponent} from "./components/containers/resident-details/resident-detail.component";
import {ResidentDetailsComponent} from "./components/presentational/resident-details/resident-details.component";
import {ResidentDetailsTabsComponent} from "./components/presentational/resident-details-tabs/resident-details-tabs.component";
import {ResidentListFormComponent} from "./components/presentational/resident-list-form/resident-list-form.component";
import {ResidentCreateComponent} from "./components/containers/resident-create/resident-create.component";
import {ResidentCreateFormComponent} from "./components/presentational/resident-create-form/resident-create-form.component";
import {ResidentEditFormComponent} from "./components/presentational/resident-edit-form/resident-edit-form.component";
import {ResidentCareplanEditComponent} from "./components/containers/resident-careplan-edit/resident-careplan-edit.component";
import {InitialCareplanComponent} from "./components/presentational/resident-careplan-tab/intial/initial.component";
import {PersonalCareplanComponent} from "./components/presentational/resident-careplan-tab/personalStuff/personal.component";
import {BathCareplanComponent} from "./components/presentational/resident-careplan-tab/bathStuff/bath.component";
import {ResidentCareplanEditFormComponent} from "./components/presentational/resident-careplan-tab/resident-careplan-edit-form.component";
import {CareplanAwarenessComponent} from "./components/presentational/resident-careplan-tab/cognition/awareness/awareness.component";
import {CareplanAdaptationComponent} from "./components/presentational/resident-careplan-tab/cognition/adaptation/adaptation.component";
import {CareplanJudgmentComponent} from "./components/presentational/resident-careplan-tab/cognition/judment/judgment.component";
import {CareplanMemoryComponent} from "./components/presentational/resident-careplan-tab/cognition/memory/memory.component";
import {CareplanOrientationComponent} from "./components/presentational/resident-careplan-tab/cognition/orientation/orientation.component";
import {CareplanDangerComponent} from "./components/presentational/resident-careplan-tab/cognition/danger/danger.component";
import {CareplanwWanderingComponent} from "./components/presentational/resident-careplan-tab/cognition/wandering/wandering.component";
import {CareplanMobilityComponent} from "./components/presentational/resident-careplan-tab/mobility/mobility.component";
import {CareplanBehavoiurComponent} from "./components/presentational/resident-careplan-tab/emotional/behavior/behaviour.component";
import {CareplanInterventionsComponent} from "./components/presentational/resident-careplan-tab/emotional/interventions/interventions.component";
import {CareplanDressingComponent} from "./components/presentational/resident-careplan-tab/emotional/dressing/dressing.component";
import {CareplanDemandsComponent} from "./components/presentational/resident-careplan-tab/cognition/demands/demands.component";
import {CareplainSignatureComponent} from "./components/presentational/resident-careplan-tab/signature/signature.component";
import {CareplanGroomingComponent} from "./components/presentational/resident-careplan-tab/emotional/grooming/grooming.component";
import {CareplanEatingComponent} from "./components/presentational/resident-careplan-tab/emotional/eating/eating.component";
import {CareplanEliminationComponent} from "./components/presentational/resident-careplan-tab/emotional/elimination/elimination.component";
import {CareplanBowelComponent} from "./components/presentational/resident-careplan-tab/emotional/bowel/bowel.component";
import {CareplanToiletingComponent} from "./components/presentational/resident-careplan-tab/emotional/toileting/toileting.component";
import {CareplanMedicalComponent} from "./components/presentational/resident-careplan-tab/issues/medical/medical.component";
import {CareplanCommunicationComponent} from "./components/presentational/resident-careplan-tab/issues/communication/communication.component";
import {CareplanEmergencyComponent} from "./components/presentational/resident-careplan-tab/issues/emergency/emergency.component";
import {CareplanTransportationComponent} from "./components/presentational/resident-careplan-tab/issues/transportation/transportation.component";
import {CareplanEnhanceComponent} from "./components/presentational/resident-careplan-tab/issues/enhance/enhance.component";

export const routes: Routes = [
  {
    path: '',
    component: ResidentComponent,
    children: [
      {
        path: 'home',
        component: ResidentPageComponent
      },
      {
        path: 'details/:id',
        component: ResidentDetailComponent
      },
      {
        path: 'add',
        component: ResidentCreateComponent
      },
      {
        path: 'edit',
        component: ResidentCreateComponent
      },
      {
        path: 'careplan/edit',
        component: ResidentCareplanEditComponent
      },
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
export class ResidentRoutingModule {
}

export const residentRoutingComponents = [
  ResidentComponent, ResidentPageComponent, ResidentHomeComponent,
  ResidentDetailComponent, ResidentDetailsComponent, ResidentDetailsTabsComponent,
  ResidentListFormComponent,
  ResidentCreateComponent, ResidentCreateFormComponent, ResidentEditFormComponent,
  ResidentCareplanEditComponent, ResidentCareplanEditFormComponent,
  InitialCareplanComponent, PersonalCareplanComponent, BathCareplanComponent,
  CareplanAwarenessComponent, CareplanAdaptationComponent, CareplanJudgmentComponent, CareplanMemoryComponent,
  CareplanOrientationComponent, CareplanDangerComponent, CareplanwWanderingComponent,
  CareplanMobilityComponent, CareplanBehavoiurComponent, CareplanInterventionsComponent, CareplanDressingComponent,
  CareplanDemandsComponent, CareplainSignatureComponent, CareplanGroomingComponent, CareplanEatingComponent,
  CareplanEliminationComponent, CareplanBowelComponent, CareplanToiletingComponent,
  CareplanMedicalComponent, CareplanCommunicationComponent, CareplanEmergencyComponent, CareplanTransportationComponent,
  CareplanEnhanceComponent
];
