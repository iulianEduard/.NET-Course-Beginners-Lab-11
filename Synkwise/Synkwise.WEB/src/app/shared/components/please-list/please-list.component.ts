/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Output, EventEmitter, Input} from '@angular/core';

import {FormGroup, FormControl, Validators} from '@angular/forms';
import {EmailValidator} from "../../validators/email.validator";
import {PhoneValidator} from "../../validators/phone.validator";
import {Constants} from "../../utils";

@Component({
  selector: 'synkwise-please-list',
  templateUrl: 'please-list.component.html',
  styleUrls: ['please-list.component.css']
})
export class PleaseListComponent implements OnInit {
  @Input() itemDetails = new EventEmitter<any>();

  private itemForm: FormGroup;
  private inputName: any;

  constructor() {
    this.inputName = {
      input1: "Resident’s preferences and abilities",
      input2: "Caregiver’s responsibilities (what and when)"
    };

    this.itemForm = new FormGroup({
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
}
