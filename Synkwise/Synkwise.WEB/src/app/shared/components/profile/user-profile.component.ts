/**
 * Created by coprita on 12/18/2017.
 */
import {Component, OnInit, Output, EventEmitter} from '@angular/core';

import {FormGroup, FormControl, Validators} from '@angular/forms';
import {EmailValidator} from "../../validators/email.validator";
import {PhoneValidator} from "../../validators/phone.validator";
import {Constants} from "../../utils";

@Component({
  selector: 'synkwise-user-profile',
  templateUrl: 'user-profile.component.html',
  styleUrls: ['user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  @Output() save = new EventEmitter<any>();

  phoneMask: any = Constants.PHONE_MASK;
  userProfileForm: FormGroup;

  constructor() {
    this.userProfileForm = new FormGroup({
      Id: new FormControl(''),
      firstName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      address: new FormControl('', [Validators.required, Validators.maxLength(150)]),
      email: new FormControl('', [Validators.required, EmailValidator.isValid, Validators.maxLength(50)]),
      phoneNumber: new FormControl('', [Validators.required, PhoneValidator.isValid]),
      faxNumber: new FormControl('', []),
      city: new FormControl('', [Validators.required]),
      state: new FormControl('', [Validators.required]),
      zipCode: new FormControl('', [Validators.required])
    });
  }

  ngOnInit() {

  }

  onSubmit({value, valid}: { value: any, valid: any }) {
    debugger;
    if (valid) {
      value.providerId = 1;
      this.save.emit(value);
    } else {
      return;
    }
  }
}
