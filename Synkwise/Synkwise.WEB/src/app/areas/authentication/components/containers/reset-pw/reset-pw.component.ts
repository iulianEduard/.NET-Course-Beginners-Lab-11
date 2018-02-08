import {Component} from '@angular/core';

import {AuthService} from "../../../services/authentication.service";
import {ToasterService} from "angular2-toaster";
import {Router} from "@angular/router";

@Component({
  templateUrl: './reset-pw.component.html',
  styleUrls: ['./reset-pw.component.css']
})
export class ResetPasswordComponent {

  constructor(private authService: AuthService, private toasterService: ToasterService,
              private router: Router) {
  }

  resetPassword(passwordModel: any) {
    this.authService.resetPasword(passwordModel).subscribe(result => {
      var registerResult = result;
      this.toasterService.pop('success', 'Reset Password', "You have successfully reset your password.");
      this.router.navigateByUrl('/authentication/login');
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
    });
  }
}
