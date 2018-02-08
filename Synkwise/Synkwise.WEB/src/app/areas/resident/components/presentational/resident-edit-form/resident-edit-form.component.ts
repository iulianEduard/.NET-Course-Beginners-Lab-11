/**
 * Created by coprita on 12/5/2017.
 */
import {
  Component, ChangeDetectionStrategy, OnInit, Output, EventEmitter, Input, SimpleChanges,
  OnChanges, ViewChild
} from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms';
import {Constants} from "../../../../../shared/utils";
import {PhoneValidator} from "../../../../../shared/validators/phone.validator";
import {isNullOrUndefined} from "util";
declare var Materialize: any;

@Component({
  selector: 'resident-edit-form',
  templateUrl: 'resident-edit-form.component.html',
  styleUrls: ['resident-edit-form.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResidentEditFormComponent implements OnInit, OnChanges {
  @Output() createResident = new EventEmitter<any>();
  @Input() facilityList: Array<any> = [];
  @Input() residentForEdit: any = {};

  private residentEditModel: any = {};
  residentModel: FormGroup;

  phoneMask: any = Constants.PHONE_MASK;
  heightMask: any = Constants.HEIGHT_MASK;

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
      primaryCaregiverPhone: new FormControl(''),
      dateOfBirth: new FormControl(''),
      weight: new FormControl(''),
      height: new FormControl(''),

      medicareNumber : new FormControl(''),
      medicAidNumber: new FormControl(''),
      vaNumber: new FormControl(''),
      insurance: new FormControl(''),
      insuranceClaimNumber: new FormControl(''),
      caseManagerContactID: new FormControl(''),
      caseManagerPhone: new FormControl(''),
      medicalDiagnosis: new FormControl(''),
      behavioralConditions: new FormControl(''),
      medications: new FormControl(''),
      treatments: new FormControl(''),
      polst: new FormControl(''),
      advancedHealthCareDirective: new FormControl({ value: '', disabled: false }, []),
      funeralPlan: new FormControl('')
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

      if (this.residentForEdit.height) {
        this.residentModel.controls["height"].setValue(this.residentForEdit.height);
      }

      if (this.residentForEdit.weight) {
        this.residentModel.controls["weight"].setValue(this.residentForEdit.weight);
      }

      if (this.residentForEdit.dateOfBirth) {
        this.residentModel.controls["dateOfBirth"].setValue(this.residentForEdit.dateOfBirth);
      }

      if (this.residentForEdit.medicareNumber) {
        this.residentModel.controls["medicareNumber"].setValue(this.residentForEdit.medicareNumber);
      }

      if (this.residentForEdit.medicAidNumber) {
        this.residentModel.controls["medicAidNumber"].setValue(this.residentForEdit.medicAidNumber);
      }

      if (this.residentForEdit.vaNumber) {
        this.residentModel.controls["vaNumber"].setValue(this.residentForEdit.vaNumber);
      }

      if (this.residentForEdit.insurance) {
        this.residentModel.controls["insurance"].setValue(this.residentForEdit.insurance);
      }

      if (this.residentForEdit.insuranceClaimNumber) {
        this.residentModel.controls["insuranceClaimNumber"].setValue(this.residentForEdit.insuranceClaimNumber);
      }

      if (this.residentForEdit.caseManagerContactID) {
        this.residentModel.controls["caseManagerContactID"].setValue(this.residentForEdit.caseManagerContactID);
      }

      if (this.residentForEdit.caseManagerPhone) {
        this.residentModel.controls["caseManagerPhone"].setValue(this.residentForEdit.caseManagerPhone);
      }

      if (this.residentForEdit.medicalDiagnosis) {
        this.residentModel.controls["medicalDiagnosis"].setValue(this.residentForEdit.medicalDiagnosis);
      }

      if (this.residentForEdit.behavioralConditions) {
        this.residentModel.controls["behavioralConditions"].setValue(this.residentForEdit.behavioralConditions);
      }

      if (this.residentForEdit.medications) {
        this.residentModel.controls["medications"].setValue(this.residentForEdit.medications);
      }

      if (this.residentForEdit.treatments) {
        this.residentModel.controls["treatments"].setValue(this.residentForEdit.treatments);
      }

      if (!isNullOrUndefined(this.residentForEdit.polst)) {
        this.residentModel.controls["polst"].setValue(this.residentForEdit.polst.toString());
      }

      if (!isNullOrUndefined(this.residentForEdit.advancedHealthCareDirective)) {
        this.residentModel.controls["advancedHealthCareDirective"].setValue(this.residentForEdit.advancedHealthCareDirective.toString());
      }

      if (this.residentForEdit.funeralPlan) {
        this.residentModel.controls["funeralPlan"].setValue(this.residentForEdit.funeralPlan);
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

  setDateofBirth(value){
    this.residentForEdit.dateOfBirth = value;
    this.residentModel.controls["dateOfBirth"].setValue(value);
  }

  setDateAdmission(value){
    this.residentForEdit.dateOfAdmission = value;
    this.residentModel.controls["dateOfAdmission"].setValue(value);
  }
}
