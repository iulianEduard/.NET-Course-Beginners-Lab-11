/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-dressing',
  templateUrl: 'dressing.component.html',
  styleUrls: ['dressing.component.css']
})
export class CareplanDressingComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemDressingDetails: any;

  ngOnInit() {
    this.itemDressingDetails = [{label: "Daytime", id1:"dressingInput1", id2:"dressingInput2"},
      {label: "Nighttime", id1: "residentDressingNight1", id2: "residentDressingNigh2"},
      {label: "Assistive devices", id1: "dressingAssistive", span:true},
      {label: "Equipment/supplies", id1: "dressingEquip", span:true},
      {label: "Caregiver’s time spent", id1: "residentAdaTime1", id2: "caregiverAdapTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemDressingDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
