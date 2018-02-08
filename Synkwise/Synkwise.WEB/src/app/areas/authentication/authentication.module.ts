/**
 * Created by coprita on 11/19/2017.
 */
import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpModule} from "@angular/http";

import {LoginComponent} from './components/containers/login/login.component';
import {authenticationRoutingComponents, AuthenticationRoutingModule} from './authentication.routing.module';

import {SharedModule} from "../../shared/shared.module";
import {AuthService} from "./services/authentication.service";

@NgModule({
  declarations: [
    authenticationRoutingComponents
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    AuthenticationRoutingModule,
    SharedModule,
    HttpModule
  ],
  providers: [
    AuthService
  ],
  bootstrap: [
    LoginComponent
  ]
})
export class AuthenticationModule {
}
