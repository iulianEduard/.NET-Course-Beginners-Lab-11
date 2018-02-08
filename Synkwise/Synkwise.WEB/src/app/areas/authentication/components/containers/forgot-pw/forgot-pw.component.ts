import {Component} from '@angular/core';

// import {Observable} from 'rxjs/Observable';
import {AuthService} from "../../../services/authentication.service";
import {ToasterService} from "angular2-toaster";
import {Router} from "@angular/router";

@Component({
  templateUrl: 'forgot-pw.component.html',
  styleUrls: ['forgot-pw.component.css']
})
export class ForgotPwComponent {

  // isLoading$: Observable<boolean>;;

  constructor(private auth: AuthService, private toasterService: ToasterService,
              private router: Router) {
  }

  forgotPassword(email: any) {
    this.auth.forgotPasword(email).subscribe(result => {
      this.toasterService.pop('success', 'Forgot Password', "Please check your email address to finish reset password.");
      this.router.navigateByUrl('/authentication/login');
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
    });
  }
}
