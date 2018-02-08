/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-wandering',
  templateUrl: 'wandering.component.html',
  styleUrls: ['wandering.component.css']
})
export class CareplanwWanderingComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemWanderingDetails: any;

  ngOnInit() {
    this.itemWanderingDetails = [{label: "Wanders within the home, but does not jeopardize safety", id1:"wanderingInput1", id2:"wanderingInput2"},
      {label: "Wandering jeopardizes safety", id1: "residentwandering1", id2: "residentwandering2"},
      {label: "Exit seeker", id1: "residentWanderintExit1", id2: "residentWanderintExit2"},
      {label: "Elopement risk", id1: "residentwanderingOther1", id2: "caregiverwanderingOther2"},
      {label: "Triggers/interventions", id1: "residentWanderingTrig1", id2: "caregiverWanderingTrig2"},
      {label: "Caregiver’s time spent", id1: "residentwanderingTime1", id2: "caregiverwanderingTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemWanderingDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
