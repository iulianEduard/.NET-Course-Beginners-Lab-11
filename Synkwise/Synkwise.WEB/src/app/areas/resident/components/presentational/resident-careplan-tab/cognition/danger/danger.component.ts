/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-danger',
  templateUrl: 'danger.component.html',
  styleUrls: ['danger.component.css']
})
export class CareplanDangerComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemDangerDetails: any;

  ngOnInit() {
    this.itemDangerDetails = [{label: "Aggressive/disruptive (may be in a non-physical way)", id1:"dangerInput1", id2:"dangerInput2"},
      {label: "Self-injury", id1: "residentdangerSelf1", id2: "caregiverdangerSelf2"},
      {label: "Physically abusive", id1: "residentdangerPhy1", id2: "caregiverdangerPhy2"},
      {label: "Sexually aggressive", id1: "residentaDangerSexually1", id2: "caregiverDangerSexually2"},
      {label: "Triggers/interventions", id1: "residentDangerTrig1", id2: "residentDangerTrig1"},
      {label: "Caregiver’s time spent", id1: "residentDangerTime1", id2: "caregiverDangerTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemDangerDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
