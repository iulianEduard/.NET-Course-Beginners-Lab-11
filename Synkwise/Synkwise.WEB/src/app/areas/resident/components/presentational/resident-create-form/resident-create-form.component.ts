/**
 * Created by coprita on 12/5/2017.
 */
import {
  Component, ChangeDetectionStrategy, OnInit, Output, EventEmitter, Input, SimpleChanges,
  OnChanges
} from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms';
import {Constants} from "../../../../../shared/utils";
import {PhoneValidator} from "../../../../../shared/validators/phone.validator";
declare var Materialize: any;

@Component({
  selector: 'resident-create-form',
  templateUrl: 'resident-create-form.component.html',
  styleUrls: ['resident-create-form.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResidentCreateFormComponent implements OnInit, OnChanges {
  @Output() createResident = new EventEmitter<any>();
  @Input() facilityList: Array<any> = [];
  @Input() residentForEdit: any = {};
  private residentEditModel: any = {};
  residentModel: FormGroup;

  phoneMask: any = Constants.PHONE_MASK;

  constructor() {
  }

  ngOnInit() {
    this.residentModel = new FormGroup({
      id: new FormControl(''),
      statusID: new FormControl(''),
      contactID: new FormControl(''),
      facilityID: new FormControl('', [Validators.required]),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      dateOfAdmission: new FormControl(''),
      address: new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      zipCode: new FormControl(''),
      phone: new FormControl('', [PhoneValidator.isValid]),
      livingSituation: new FormControl(''),
      livingDuration: new FormControl(''),
      primaryCaregiverFirstName: new FormControl(''),
      primaryCaregiverLastName: new FormControl(''),
      primaryCaregiverPhone: new FormControl('')
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['residentForEdit'] && this.residentForEdit) {
      this.residentEditModel = this.residentForEdit;
      if (!this.residentForEdit || !this.residentForEdit.contact) return;

      if (this.residentForEdit.id) {
        this.residentModel.controls["id"].setValue(this.residentForEdit.id);
      }
      if (this.residentForEdit.statusID) {
        this.residentModel.controls["statusID"].setValue(this.residentForEdit.statusID);
      }
      if (this.residentForEdit.contactID) {
        this.residentModel.controls["contactID"].setValue(this.residentForEdit.contactID);
      }

      if (this.residentForEdit.dateOfAdmission) {
        this.residentModel.controls["dateOfAdmission"].setValue(this.residentForEdit.dateOfAdmission);
      }

      if (this.residentForEdit.contact.firstName) {
        this.residentModel.controls["firstName"].setValue(this.residentForEdit.contact.firstName);
      }

      if (this.residentForEdit.contact.lastName) {
        this.residentModel.controls["lastName"].setValue(this.residentForEdit.contact.lastName);
      }

      if (this.residentForEdit.facilityID) {
        this.residentModel.controls["facilityID"].setValue(this.residentForEdit.facilityID);
      }

      if (this.residentForEdit.contact.address) {
        this.residentModel.controls["address"].setValue(this.residentForEdit.contact.address);
      }

      if (this.residentForEdit.contact.city) {
        this.residentModel.controls["city"].setValue(this.residentForEdit.contact.city);
      }

      if (this.residentForEdit.contact.state) {
        this.residentModel.controls["state"].setValue(this.residentForEdit.contact.state);
      }

      if (this.residentForEdit.contact.zipcode) {
        this.residentModel.controls["zipCode"].setValue(this.residentForEdit.contact.zipcode);
      }

      if (this.residentForEdit.contact.phone) {
        this.residentModel.controls["phone"].setValue(this.residentForEdit.contact.phone);
      }

      if (this.residentForEdit.livingSituation) {
        this.residentModel.controls["livingSituation"].setValue(this.residentForEdit.livingSituation);
      }

      if (this.residentForEdit.livingDuration) {
        this.residentModel.controls["livingDuration"].setValue(this.residentForEdit.livingDuration);
      }

      if (this.residentForEdit.primaryCaregiverFirstName) {
        this.residentModel.controls["primaryCaregiverFirstName"].setValue(this.residentForEdit.primaryCaregiverFirstName);
      }

      if (this.residentForEdit.primaryCaregiverPhone) {
        this.residentModel.controls["primaryCaregiverPhone"].setValue(this.residentForEdit.primaryCaregiverPhone);
      }

      Materialize.updateTextFields();
    }
  }

  onSubmit({value, valid}: { value: any, valid: boolean }) {
    if (valid) {
      this.createResident.emit(value);
    } else {
      return;
    }
  }

  setDateAdmission(value){
    this.residentForEdit.dateOfAdmission = value;
    this.residentModel.controls["dateOfAdmission"].setValue(value);
  }
}
