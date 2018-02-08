import {Component, Inject, OnInit} from '@angular/core';
import {Router, ActivatedRoute, Params} from '@angular/router';

import {AuthService} from "../../../services/authentication.service";
import {ToasterService} from "angular2-toaster";
import {Observable} from "rxjs";

@Component({
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {
  registerCode: string;
  $invitationEmail: Observable<string>;
  expiredCode: boolean;

  constructor(private Auth: AuthService, private router: Router,
              private toasterService: ToasterService, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.registerCode = params['code'];
    });
  }

  ngOnInit() {
    this.Auth.validateRegisterCode(this.registerCode).subscribe(result => {
      if (result.status == 200) {
        this.$invitationEmail = result.message;
      }
      else {
        this.toasterService.pop('Error', 'Register Code', result.message.error);
      }
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
        this.expiredCode = errorObject.ResponseStatus.Message === "Invitation code is expired!";
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }

  registerUser(user: any): void {
    this.Auth.register(user).subscribe(result => {
      var registerResult = result;
      this.toasterService.pop('success', 'Registration', "You have successfully registered. Please check your email and confirm your email address.");
      this.router.navigateByUrl('/authentication/login');
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
    });
  }
}
