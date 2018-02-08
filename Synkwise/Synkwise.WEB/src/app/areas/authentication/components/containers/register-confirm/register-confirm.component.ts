/**
 * Created by coprita on 11/27/2017.
 */
import {Component, ChangeDetectionStrategy, OnInit, Output, EventEmitter} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {AuthService} from "../../../services/authentication.service";
import {ToasterService} from "angular2-toaster";

@Component({
  selector: 'register-confirm',
  templateUrl: 'register-confirm.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterConfirmFromComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private  auth: AuthService,
              private  toasterService: ToasterService,
              private router: Router) {
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params: Params) => {
      let userId = params['userId'];
      let invitationId = params['invitationId'];
      this.auth.confirmRegistration(params).subscribe(result => {
        var registerResult = result;
        this.toasterService.pop('success', 'Register Confirmation', "Thank you for confirming your registration. You can login with your account data.");
        this.router.navigateByUrl('/authentication/login');
      }, (error: Error) => {
        if (JSON.parse(error.message)) {
          var errorObject = JSON.parse(error.message);
          this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
        }
        else this.toasterService.pop('error', 'Error', "Connection Error");
      });
    });
  }
}
