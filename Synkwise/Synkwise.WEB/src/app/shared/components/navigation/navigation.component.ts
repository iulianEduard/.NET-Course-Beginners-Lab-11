import {Component, OnInit, ElementRef, Output, EventEmitter} from '@angular/core';
import { BehaviorSubject } from "rxjs";
import { Router } from "@angular/router";

import { StorageService } from "../../services/storage.service/storage.service";

declare var jQuery: any;

@Component({
  selector: 'app-navigation',
  templateUrl: 'navigation.component.html',
  styleUrls: ['navigation.component.css']
})
export class NavigationComponent implements OnInit {
  loggedUsername: string = undefined;
  profileURL:string = '/management/home';

  constructor(private el: ElementRef, private router: Router, private storageService: StorageService) {
  }

  ngOnInit() {
    this.loggedUsername = this.storageService.getLoggedUsername().split("@")[0];
    jQuery(this.el.nativeElement).find('.button-collapse').sideNav();
    jQuery('.dropdown-button').dropdown();

    this.profileURL = '/provider/profile';
  }

  logout() {
    this.storageService.removeLoggedUser();
    this.router.navigateByUrl('/authentication/login');
  }
}
