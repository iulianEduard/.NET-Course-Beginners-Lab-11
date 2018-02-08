/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-judgment',
  templateUrl: 'judgment.component.html',
  styleUrls: ['judgment.component.css']
})
export class CareplanJudgmentComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemJudgmentDetails: any;

  ngOnInit() {
    this.itemJudgmentDetails = [{label: "Ability to identify choices", id1:"judgmentInput1", id2:"judgmentInput2"},
      {label: "Ability to understand benefits, risks and consequences", id1: "residentjudgmentAbility1", id2: "caregiverjudgmentAbility2"},
      {label: "Triggers/interventions", id1: "residentJudgmentTrig1", id2: "caregiverJudgmentTrig2"},
      {label: "Other", id1: "residentJudgmentOther1", id2: "caregiverJudgmentOther2"},
      {label: "Caregiver’s time spent", id1: "residentJudgmentTime1", id2: "caregiverJudgmentTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemJudgmentDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
