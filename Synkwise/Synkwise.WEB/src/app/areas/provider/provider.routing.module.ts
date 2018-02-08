import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { ProviderComponent } from './provider.component';
import {ProviderPageComponent} from './components/containers/provider-page/provider-page.component';
import {EditProviderComponent} from './components/containers/edit-provider/edit-provider.component';
import {EditProviderFormComponent} from './components/presentational/edit-provider-form/edit-provider-form.component';
import {ProviderHomeComponent} from './components/presentational/provider-home/provider-home.component';

export const routes: Routes = [
  {
    path: '',
    component: ProviderComponent,
    children: [
      {
        path: 'home',
        component: ProviderPageComponent
      },
      {
        path: 'edit',
        component: EditProviderComponent
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
export class ProviderRoutingModule { }

export const routingComponents = [
  ProviderComponent,
  ProviderPageComponent,
  EditProviderComponent,
  EditProviderFormComponent,
  ProviderHomeComponent
];
