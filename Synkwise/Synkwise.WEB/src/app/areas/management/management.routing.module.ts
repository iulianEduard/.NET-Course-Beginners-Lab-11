import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';

import {ManagementComponent} from "./management.component";
import {UserGridComponent} from "./components/presentational/user-grid/user-grid.component";
import {ManagementPageComponent} from "./components/containers/management-page/management-page.component";
import {InvitationCreateFromComponent} from "./components/presentational/invitation-create-form/invitation-create-form.component";
import {InvitationPageComponent} from "./components/containers/invitation-page/invitation-page.component";
import {InvitationGridComponent} from "./components/presentational/invitation-grid/invitation-grid.component";

export const routes: Routes = [
  {
    path: '',
    component: ManagementComponent,
    children: [
      {
        path: 'home',
        component: ManagementPageComponent
      },
      {
        path: 'users',
        component: UserGridComponent
      },
      {
        path: 'invitation/send',
        component: InvitationPageComponent
      },
      {
        path: 'invitation/edit',
        component: InvitationPageComponent
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
export class ManagementRoutingModule {
}

export const routingComponents = [
  ManagementComponent,
  ManagementPageComponent,
  UserGridComponent,
  InvitationPageComponent, InvitationCreateFromComponent,
  InvitationGridComponent
];
