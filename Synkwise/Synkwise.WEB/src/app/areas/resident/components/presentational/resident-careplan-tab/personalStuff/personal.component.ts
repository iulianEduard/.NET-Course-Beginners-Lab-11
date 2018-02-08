/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';
import {Constants} from "../../../../../../shared/utils";

@Component({
  selector: 'synkwise-resident-careplan-personal',
  templateUrl: 'personal.component.html',
  styleUrls: ['personal.component.css']
})
export class PersonalCareplanComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemPersonalDetails: any;
  private inputName: any;
  private pleaseList: any;

  ngOnInit() {
    this.inputName = {
      input1: "Resident’s preferences and abilities",
      input2: "Caregiver’s responsibilities (what and when)"
    };
    this.itemPersonalDetails = [{
      label: "Shave area/frequency",
      input1: "residentPref",
      input2: "caregiverResp",
      id1: "personalShaveResID",
      id2: "personalShaveCareID"
    },
      {label: "Teeth brushing frequency", input1: "residentPref", input2: "caregiverResp"},
      {label: "Oral care", input1: "residentPref", input2: "caregiverResp"},
      {label: "Allergies to personal hygiene items", input1: "residentPref", input2: "caregiverResp"}];

    this.pleaseList = [
      {label: "Assistive devices", model: "assistanceDevice", id: "personalPLAssistID", span: true},
      {label: "Equipment/supplies", model: "equipment", id: "personalPLEquipID", span: true},
      {label: "Consultation, teaching, delegation and/or assessment", model: "consultationTeach", id: "personalPLConsultID", span: true},
      {label: "Caregiver’s time spent", model1: "residentTimeSpent",model2: "caregiverTimeSpent", id1:"personalPLResiID", id2:"personalPLCaregID"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemPersonalDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
