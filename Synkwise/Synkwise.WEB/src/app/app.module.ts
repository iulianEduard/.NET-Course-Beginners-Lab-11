import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// import { MaterializeModule } from "angular2-materialize/dist";
import {ToasterModule } from 'angular2-toaster';
import { SharedModule } from "./shared/shared.module";

import { AppComponent } from './app.component';
import { AppRoutingModule } from "./app.routing.module";
import {AuthGuard} from "./_guards/auth.guard";
import {AuthenticationModule} from "./areas/authentication/authentication.module";
import {TextMaskModule} from "angular2-text-mask";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    // MaterializeModule,
    SharedModule,
    AuthenticationModule,
    ToasterModule,
    TextMaskModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
