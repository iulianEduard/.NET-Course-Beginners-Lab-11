/**
 * Created by coprita on 11/23/2017.
 */
import { Component, ChangeDetectionStrategy, OnInit, Output, EventEmitter} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { LoginModel } from '../../../../../shared/models/login/loginModel';

@Component({
  selector: 'login-form',
  templateUrl: 'login-form.component.html',
  styleUrls: ['login-form.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginFormComponent implements OnInit {
  @Output() loginUser = new EventEmitter<any>();

  user: LoginModel = new LoginModel();

  ngOnInit() {
    this.user = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });
  }

  onSubmit({value, valid}: { value: any, valid: boolean }) {
    if (valid)   {
      this.loginUser.emit(value);
    }
  }
}
