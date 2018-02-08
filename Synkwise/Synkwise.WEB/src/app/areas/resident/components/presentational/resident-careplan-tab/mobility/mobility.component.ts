/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';
import {Constants} from "../../../../../../shared/utils";

@Component({
  selector: 'synkwise-resident-careplan-mobility',
  templateUrl: 'mobility.component.html',
  styleUrls: ['mobility.component.css']
})
export class CareplanMobilityComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemMobilityDetails: any;
  private inputName: any;

  ngOnInit() {
    this.inputName = {
      input1: "Resident’s preferences and abilities",
      input2: "Caregiver’s responsibilities (what and when)"
    };
    this.itemMobilityDetails = [
      {
        label: "Ability to move around inside",
        input1: "residentPref",
        input2: "caregiverResp",
        id1: "mobilityInside1ID",
        id2: "mobilityInside2ID"
      },
      {label: "Ability to move outside", id1: "mobilityOutside1ID", id2: "mobilityOutside2ID"},
      {label: "Fall risk", id1: "mobilityRisk1ID", id2: "mobilityRisk1ID"},

      {label: "Assistive devices", id1: "residentdevice1", span: true},
      {label: "Equipment/supplies", id1: "mobilityEquip1", span: true},
      {label: "Consultation, teaching, delegation and/or assessment", id1: "mobilityConsult1", span: true},

      {label: "Caregiver’s time spent", id1: "caregiverTime1", id2: "caregiverTime2"},
      {label: "Ability to move to and from a chair or wheelchair", id1: "mobilityChair1", id2: "mobilityChair2"},
      {label: "Ability to move to and from bed", id1: "mobilityBed1", id2: "mobilityBed2"},

      {label: "Caregiver’s ????????", id1: "mobilityCare1", span: true},
      {label: "Assistive devices", id1: "mobilityAssistDevice1", span: true},
      {label: "Equipment/supplies", id1: "mobilityEquipSuppli1", span: true},
      {label: "Consultation, teaching, delegation and/or assessment", id1: "mobilityTeach1", span: true},

      {label: "Caregiver’s time spent", id1: "mobilityCareTime1", id2: "mobilityCareTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemMobilityDetails = this.initialDetails;
    }
  }
}
