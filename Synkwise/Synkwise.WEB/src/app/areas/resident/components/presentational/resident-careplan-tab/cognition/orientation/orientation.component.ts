/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-orientation',
  templateUrl: 'orientation.component.html',
  styleUrls: ['orientation.component.css']
})
export class CareplanOrientationComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemOrientationDetails: any;

  ngOnInit() {
    this.itemOrientationDetails = [
      {label: "Ability to understand and recognize person/place/time for health/safety", id1: "residentorientationAbility1", id2: "caregiverjudgmentAbility2"},
      {label: "Triggers/interventions", id1: "residentorientationTrig1", id2: "caregiverorientationTrig2"},
      {label: "Other", id1: "residentorientationOther1", id2: "caregiverorientationOther2"},
      {label: "Caregiver’s time spent", id1: "residentorientationTime1", id2: "caregiverorientationTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemOrientationDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
