import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ReactiveFormsModule, FormsModule} from "@angular/forms";
import {TextMaskModule} from "angular2-text-mask";
import {RouterModule} from "@angular/router";

import {FooterComponent} from './components/footer/footer.component';
import {NavigationComponent} from './components/navigation/navigation.component';
import {UserProfileComponent} from "./components/profile/user-profile.component";

import {ApiService} from "./services/api.service/api.service";
import {StorageService} from "./services/storage.service/storage.service";
import {CommonService} from "./services/common.service/common.service";
import {PagerService} from "./services/table.service/pager.service";
import {SearchInputComponent} from "./components/search-input/search-input.component";
import {MyDatePickerModule} from "mydatepicker";
import {DateInputComponent} from "./components/date-input/date-input.component";
import {ProfileTabComponent} from "./components/resident/profileTab/profileTab.component";
import {PleaseListComponent} from "./components/please-list/please-list.component";

@NgModule({
  providers: [
    ApiService,
    StorageService,
    CommonService,
    PagerService
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    TextMaskModule,
    MyDatePickerModule
  ],
  declarations: [
    FooterComponent,
    NavigationComponent,
    UserProfileComponent,
    SearchInputComponent,
    DateInputComponent,
    ProfileTabComponent,
    PleaseListComponent
  ],
  exports: [
    FooterComponent,
    NavigationComponent,
    UserProfileComponent,
    SearchInputComponent,
    DateInputComponent,
    ProfileTabComponent,
    PleaseListComponent
  ]
})
export class SharedModule {
}
