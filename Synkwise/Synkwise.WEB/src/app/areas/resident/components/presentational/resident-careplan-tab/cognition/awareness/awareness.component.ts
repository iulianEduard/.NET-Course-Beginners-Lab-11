/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-awareness',
  templateUrl: 'awareness.component.html',
  styleUrls: ['awareness.component.css']
})
export class CareplanAwarenessComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemAwarenessDetails: any;

  ngOnInit() {
    this.itemAwarenessDetails = [{label: "Ability to understand basic health needs", id1:"awarenessInput1", id2:"awarenessInput2"},
      {label: "Ability to understand basic safety needs", id1: "residentawarenessTrig1", id2: "caregiverawarenessTrig2"},
      {label: "Triggers/interventions", id1: "residentAwareTrig1", id2: "caregiverAwareTrig2"},
      {label: "Other", id1: "residentAwareOther1", id2: "caregiverAwareOther2"},
      {label: "Caregiver’s time spent", id1: "residentAwareTime1", id2: "caregiverAwareTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemAwarenessDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
