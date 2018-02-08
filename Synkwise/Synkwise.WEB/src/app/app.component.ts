import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { StorageService } from "./shared/services/storage.service/storage.service";
import {ToasterConfig} from "angular2-toaster";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [StorageService]
})
export class AppComponent implements OnInit{
  toasterConfig: ToasterConfig = new ToasterConfig({
    // positionClass: 'toast-top-right',
    showCloseButton: true,
    tapToDismiss: true,
    timeout: 5000
  });
  title = 'app';
  loggedIn$: Observable<boolean>;

  constructor(private storageService: StorageService) {

  }

  ngOnInit() {
    this.loggedIn$ = this.storageService.isLoggedIn;
  }
}
