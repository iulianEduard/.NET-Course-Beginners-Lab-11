import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AuthGuard} from "./_guards/auth.guard";

const routes: Routes = [
  {
    path: 'authentication',
    loadChildren: 'app/areas/authentication/authentication.module#AuthenticationModule'
  },
  {
    path: 'provider',
    loadChildren: 'app/areas/provider/provider.module#ProviderModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'facility',
    loadChildren: 'app/areas/facility/facility.module#FacilityModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'resident',
    loadChildren: 'app/areas/resident/resident.module#ResidentModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'management',
    loadChildren: 'app/areas/management/management.module#ManagementModule',
    canActivate: [AuthGuard]
  },
  {
    path: '',
    redirectTo: '/provider',
    pathMatch: 'full',
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
