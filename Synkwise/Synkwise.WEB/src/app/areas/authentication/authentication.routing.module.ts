/**
 * Created by coprita on 11/19/2017.
 */
import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';

import {AuthenticationComponent} from "./authentication.component";
import {LoginComponent} from "./components/containers/login/login.component";
import {LoginFormComponent} from './components/presentational/login-form/login-form.component';
import {ForgotPwComponent} from "./components/containers/forgot-pw/forgot-pw.component";
import {ForgotPwFormComponent} from "./components/presentational/forgot-pw-form/forgot-pw-form.component";
import {RegisterComponent} from "./components/containers/register/register.component";
import {RegisterFromComponent} from "./components/presentational/register-form/register-form.component";
import {RegisterConfirmFromComponent} from "./components/containers/register-confirm/register-confirm.component";
import {ResetPasswordComponent} from "./components/containers/reset-pw/reset-pw.component";
import {ResetPasswordFormComponent} from "./components/presentational/reset-pw-form/reset-pw-form.component";

export const routes: Routes = [
  {
    path: '',
    component: AuthenticationComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'forgot',
        component: ForgotPwComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'confirm/:userId/:invitationId',
        component: RegisterConfirmFromComponent
      },
      {
        path: 'resetpwd/:userId/:code',
        component: ResetPasswordComponent
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
export class AuthenticationRoutingModule {
}

export const authenticationRoutingComponents = [
  AuthenticationComponent,
  LoginComponent, LoginFormComponent,
  ForgotPwComponent, ForgotPwFormComponent,
  RegisterComponent, RegisterFromComponent, RegisterConfirmFromComponent,
  ResetPasswordComponent, ResetPasswordFormComponent
];
