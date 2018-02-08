import { Injectable } from '@angular/core';
import { BehaviorSubject } from "rxjs";

import * as userModels from '../../models/login/userModel';

@Injectable()
export class StorageService {

  loggedIn$ = new BehaviorSubject<boolean>(true);

  private auth = {
    key: 'user',
    value: null
  };

  constructor() {
    this.loggedIn$.next(this.getLoggedUser() ? true : false);
  }

  get isLoggedIn() {
    return this.loggedIn$.asObservable();
  }

  setLoggedUser(user: userModels.UserInfo) {
    localStorage.setItem("token", user.token);
    localStorage.setItem(this.auth.key, JSON.stringify(user));
    localStorage.setItem("username", user && user.message ? user.message.email : 'Guest');
    this.auth.value = user;
    this.loggedIn$.next(true);
  }

  getLoggedUser(): userModels.UserInfo {
    if (this.auth.value == null) {
      this.auth.value = JSON.parse(localStorage.getItem(this.auth.key));
    }

    return this.auth.value;
  }

  getLoggedUsername(): string {
    if (localStorage.getItem("username") !== null) {
      return localStorage.getItem("username");
    }

    return 'Unknown';
  }

  removeLoggedUser() {
    localStorage.clear();
    this.auth.value = null;
    this.loggedIn$.next(false);
  }
}
