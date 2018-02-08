import {Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'synkwise-facility-details-icons',
  templateUrl: 'facility-details-icons.component.html',
  styleUrls: ['facility-details-icons.component.css']
})
export class FacilityDetailsIconsComponent implements OnInit, OnChanges {
 // @Input() facility: any;
 // @Output() save = new EventEmitter<any>();

 // facilityForm: FormGroup;

  constructor() {
  /* this.facilityForm = new FormGroup({
      facilityId: new FormControl(''),
      name: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required]),
      faxNumber: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      city: new FormControl('', [Validators.required]),
      state: new FormControl('', [Validators.required]),
      zipcode: new FormControl('', [Validators.required])
    }); */
  }

  ngOnChanges(changes: SimpleChanges) {
  /*  if (changes['facility'] && this.facility) {

      if (this.facility.id > 0) {
        this.facilityForm.controls["facilityId"].setValue(this.facility.id);
      }

      if (this.facility.name) {
        this.facilityForm.controls["name"].setValue(this.facility.name);
      }

      if (this.facility.phoneNumber) {
        this.facilityForm.controls["phoneNumber"].setValue(this.facility.phoneNumber);
      }

      if (this.facility.faxNumber) {
        this.facilityForm.controls["faxNumber"].setValue(this.facility.faxNumber);
      }

      if (this.facility.address) {
        this.facilityForm.controls["address"].setValue(this.facility.address);
      }

      if (this.facility.city) {
        this.facilityForm.controls["city"].setValue(this.facility.city);
      }

      if (this.facility.state) {
        this.facilityForm.controls["state"].setValue(this.facility.state);
      }

      if (this.facility.zipcode) {
        this.facilityForm.controls["zipcode"].setValue(this.facility.zipcode);
      }
    } */
  }

  ngOnInit() {

  }

  onSubmit(value) {
   // debugger;
  //  this.save.emit(value);
  }

}
