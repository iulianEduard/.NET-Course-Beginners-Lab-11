import {Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'synkwise-edit-provider-form',
  templateUrl: 'edit-provider-form.component.html',
  styleUrls: ['./edit-provider-form.component.css']
})
export class EditProviderFormComponent implements OnInit, OnChanges {
  @Input() provider: any;
  @Output() saveProviderData = new EventEmitter<any>();

  providerForm: FormGroup;

  constructor() {
    this.providerForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required]),
      mobileNumber: new FormControl('', [Validators.required]),
      faxNumber: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      city: new FormControl('', [Validators.required]),
      state: new FormControl('', [Validators.required]),
      zipcode: new FormControl('', [Validators.required])
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['provider'] && this.provider) {

      if (this.provider.name) {
        this.providerForm.controls['name'].setValue(this.provider.name);
      }
      if (this.provider.email) {
        this.providerForm.controls['email'].setValue(this.provider.email);
      }
      if (this.provider.phoneNumber) {
        this.providerForm.controls['phoneNumber'].setValue(this.provider.phoneNumber);
      }
      if (this.provider.mobileNumber) {
        this.providerForm.controls['mobileNumber'].setValue(this.provider.mobileNumber);
      }
      if (this.provider.faxNumber) {
        this.providerForm.controls['faxNumber'].setValue(this.provider.faxNumber);
      }

      if (this.provider.address) {
        this.providerForm.controls['address'].setValue(this.provider.address);
      }

      if (this.provider.city) {
        this.providerForm.controls['city'].setValue(this.provider.city);
      }

      if (this.provider.state) {
        this.providerForm.controls['state'].setValue(this.provider.state);
      }

      if (this.provider.zipcode) {
        this.providerForm.controls['zipcode'].setValue(this.provider.zipcode);
      }
    }
  }

  ngOnInit() {

  }

  onSubmit(value) {
    debugger;
    this.saveProviderData.emit(value);
  }

}
