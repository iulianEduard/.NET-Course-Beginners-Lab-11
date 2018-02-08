/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-medical',
  templateUrl: 'medical.component.html',
  styleUrls: ['medical.component.css']
})
export class CareplanMedicalComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemMedicalDetails: any;

  ngOnInit() {
    this.itemMedicalDetails = [
      {
        label: "Health issues to monitor",
        input1: "residentPref",
        input2: "caregiverResp",
        id1: "medicalIssue1ID",
        id2: "medicalIssue2ID"
      },
      {label: "Pain management", id1: "medicalPain1ID", id2: "medicalPain2ID"},
      {label: "Treatment", id1: "medicalTreatment1ID", id2: "medicalTreatment2ID"},

      {label: "Therapies", id1: "caregiverTherapiID1", id2: "caregiverTherapiID2"},
      {label: "Procedures", id1: "medicalProcedure1", id2: "medicalProcedure2"},
      {label: "Weight/goal", id1: "medicalGoalID1", id2: "medicalGoalID2"},
      {label: "Physical restraints", id1: "medicalPhusicalID1", id2: "medicalPhusicalID2"},
      {label: "Psychoactive medications", id1: "medicalPsychoactiveID1", id2: "medicalPsychoactiveID2"},
      {label: "Medication allergies", id1: "medicalAlergiesID1", id2: "medicalAlergiesID2"},
      {label: "Physical disabilities", id1: "medicalDisabilitiesID1", id2: "medicalDisabilitiesID2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemMedicalDetails = this.initialDetails;
    }
  }
}
