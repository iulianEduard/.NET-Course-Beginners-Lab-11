/**
 * Created by coprita on 1/14/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';
import {Constants} from "../../../../../../shared/utils";

@Component({
  selector: 'synkwise-resident-careplan-signature',
  templateUrl: 'signature.component.html',
  styleUrls: ['signature.component.css']
})
export class CareplainSignatureComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemSignatureDetails: any;
  private inputName: any;

  ngOnInit() {
    this.inputName = {
      input1: "Resident’s preferences and abilities",
      input2: "Caregiver’s responsibilities (what and when)"
    };
    this.itemSignatureDetails = [{
      label: "Shave area/frequency",
      input1: "residentPref",
      input2: "caregiverResp",
      id1: "personalShaveResID",
      id2: "personalShaveCareID"
    },
      {label: "Teeth brushing frequency", input1: "residentPref", input2: "caregiverResp"},
      {label: "Oral care", input1: "residentPref", input2: "caregiverResp"},
      {label: "Allergies to personal hygiene items", input1: "residentPref", input2: "caregiverResp"}];

  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemSignatureDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
