import {Component, ChangeDetectionStrategy, OnInit, Output, EventEmitter} from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms';
import {Router, ActivatedRoute, Params} from '@angular/router';
import {PasswordValidator} from "../../../../../shared/validators/password.validator";

@Component({
  selector: 'reset-pw-form',
  templateUrl: './reset-pw-form.component.html',
  styleUrls: ['./reset-pw-form.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResetPasswordFormComponent implements OnInit {
  @Output() resetPassword = new EventEmitter<any>();

  form: FormGroup;
  private resetKey: string;
  private userId: string;

  constructor(private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe((params: Params) => {
      this.resetKey = params['code'];
      this.userId = params['userId'];
    });
  }

  ngOnInit() {
    this.form = new FormGroup({
      password: new FormControl('', [Validators.required, PasswordValidator.isValid]),
      confirmPassword: new FormControl('', [Validators.required, PasswordValidator.isValid]),
    });
  }

  onSubmit({value, valid}: { value: any, valid: boolean }) {
    if (valid) {
      value.code = this.resetKey;
      value.userId = this.userId;
      this.resetPassword.emit(value);
    } else {
      return;
    }
  }
}
