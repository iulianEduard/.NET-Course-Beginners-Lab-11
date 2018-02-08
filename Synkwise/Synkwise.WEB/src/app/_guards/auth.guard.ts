import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

// import * as moment from 'moment';

// import { ToasterService, BodyOutputType, Toast } from 'angular2-toaster';
import {StorageService} from "../shared/services/storage.service/storage.service";

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router,
        private storageService: StorageService
       // private toasterService: ToasterService,
       ) { }

    canActivate() {
        var user = this.storageService.getLoggedUser();
        if (user && user.token) {
            // const tokenCreateDate = moment(user.createdAt);
            // const now = moment();
            //
            // const diff = now.diff(tokenCreateDate, 'seconds');
            //
            // // if token is expired
            // if (diff > user.expires_in) {
            //     // logout user -> remove token
            //   this.store.dispatch(new userActions.LogoutAction());
            //   this.toasterService.pop('error', 'Error', 'Your login session has expired');
            //   return false;
            // }
            // else {
            //     return true;
            // }

            return true;
        }

        this.router.navigateByUrl('/authentication/login');
        return false;
    }
}
