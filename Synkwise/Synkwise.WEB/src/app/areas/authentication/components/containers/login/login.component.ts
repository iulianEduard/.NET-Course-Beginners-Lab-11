/**
 * Created by coprita on 11/19/2017.
 */
import {Component, Inject} from '@angular/core';
import {Router} from '@angular/router';
import {AuthService} from '../../../services/authentication.service'
import {StorageService} from "../../../../../shared/services/storage.service/storage.service";
import * as userModels from '../../../../../shared/models/login/userModel';
import {ToasterService} from "angular2-toaster";

@Component({
  selector: 'login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.css']
})
export class LoginComponent {
  constructor(private router: Router, private auth: AuthService,
              private storageService: StorageService,
              private  toasterService: ToasterService) {
  }

  loginUser(user: any): void {
    this.auth.login(user).subscribe(result => {
      if (result.status === 200) {
        var userInfo = result as userModels.UserInfo;
        this.storageService.setLoggedUser(userInfo);
        this.auth.loggedUser$.next(true);
        this.router.navigateByUrl('/provider/home');
        this.toasterService.pop('success', 'Login', "Successfully logged in!");
      }
    }, error => {
      if (typeof window !== undefined) {
        this.storageService.removeLoggedUser();
        this.auth.loggedUser$.next(false);
        this.router.navigateByUrl('/login');
      }
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        if (errorObject.message)
          this.toasterService.pop('error', 'Error', errorObject.message);
        else
          this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
    });
  }
}
