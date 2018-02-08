/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-adaptation',
  templateUrl: 'adaptation.component.html',
  styleUrls: ['adaptation.component.css']
})
export class CareplanAdaptationComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemAdaptationDetails: any;

  ngOnInit() {
    this.itemAdaptationDetails = [{label: "Ability to respond, to cope and to adjust to life changes", id1:"adaptationInput1", id2:"adaptationInput2"},
      {label: "Triggers/interventions", id1: "residentAdapTrig1", id2: "caregiverAdapTrig2"},
      {label: "Other", id1: "residentAdapOther1", id2: "caregiverAdapOther2"},
      {label: "Caregiver’s time spent", id1: "residentAdaTime1", id2: "caregiverAdapTime2"}];

  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemAdaptationDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
