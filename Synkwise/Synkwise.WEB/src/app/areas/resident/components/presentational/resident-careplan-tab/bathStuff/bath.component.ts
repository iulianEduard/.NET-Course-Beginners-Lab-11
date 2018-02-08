/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';
import {Constants} from "../../../../../../shared/utils";

@Component({
  selector: 'synkwise-resident-careplan-bath',
  templateUrl: 'bath.component.html',
  styleUrls: ['bath.component.css']
})
export class BathCareplanComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemBathDetails: any;
  private inputName: any;
  private pleaseList: any;

  ngOnInit() {
    this.inputName = {
      input1: "Resident’s preferences and abilities",
      input2: "Caregiver’s responsibilities (what and when)"
    };

    this.itemBathDetails = [{label: "Frequency", input1: "residentPref", input2: "caregiverResp", id1:"batchFrequencyID", id2:"batchFrequencyCaregiverID"},
      {label: "Bathtub or shower", input1: "residentPref", input2: "caregiverResp"},
      {label: "Hair washing frequency", input1: "residentPref", input2: "caregiverResp"},
      {label: "Allergies to bathing items", input1: "residentPref", input2: "caregiverResp"}];

    this.pleaseList = [
      {label: "Assistive devices", model: "assistanceDevice", id: "bathPLAssistID", span: true},
      {label: "Equipment/supplies", model: "equipment", id: "bathPLEquipID", span: true},
      {label: "Consultation, teaching, delegation and/or assessment", model: "consultationTeach", id: "bathPLConsultID", span: true},
      {label: "Caregiver’s time spent", model1: "residentTimeSpent",model2: "caregiverTimeSpent", id1:"bathPLResiID", id2:"bathPLCaregID"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemBathDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
