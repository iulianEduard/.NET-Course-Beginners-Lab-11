import {
  Component, ChangeDetectionStrategy, OnInit, Output, EventEmitter, Input, OnChanges,
  SimpleChanges
} from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms';
import {EmailValidator} from "../../../../../shared/validators/email.validator";
import {PasswordValidator} from "../../../../../shared/validators/password.validator";
import {ActivatedRoute, Params} from "@angular/router";
declare var Materialize: any;

@Component({
  selector: 'register-form',
  templateUrl: 'register-form.component.html',
  styleUrls: ['register-form.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterFromComponent implements OnInit, OnChanges {
  @Output() registerUser = new EventEmitter<any>();
  @Input() invitationEmail: any;
  @Input() expiredCode: boolean;

  userModel: FormGroup;
  registerCode = "";

  constructor(private activatedRoute: ActivatedRoute) {
    this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.registerCode = params['code'];
    });
  }

  ngOnInit() {
    this.userModel = new FormGroup({
      email: new FormControl('', [Validators.required, EmailValidator.isValid]),
      password: new FormControl('', [Validators.required, PasswordValidator.isValid]),
      confirmPassword: new FormControl('', [Validators.required])
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['invitationEmail'] && this.invitationEmail) {
      this.userModel.controls["email"].setValue(this.invitationEmail);

      Materialize.updateTextFields();
    }

    if (changes['expiredCode'] && this.expiredCode) {
      this.expiredCode = this.expiredCode;
    }

  }

  onSubmit({value, valid}: { value: any, valid: boolean }) {
    if (valid) {
      value.invitationCode = this.registerCode;
      this.registerUser.emit(value);
    } else {
      return;
    }
  }
}
