/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-emergency',
  templateUrl: 'emergency.component.html',
  styleUrls: ['emergency.component.css']
})
export class CareplanEmergencyComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemEmergencyDetails: any;

  ngOnInit() {
    this.itemEmergencyDetails = [{label: "Daytime plan/time", id1:"emergencyInput1", id2:"emergencyInput2"},
      {label: "Nighttime plan/time", id1: "residentemergency1", id2: "caregiveremergency"},
      {label: "When/why resident refuses to participate", id1: "residentemergencyrefuses1", id2: "caregiveremergencyrefuses2"},
      {label: "When/why resident cannot participate", id1: "residentemergencyparticipate1", id2: "caregiveremergencyparticipate2"},
      {label: "Evacuation plan w/proxy", id1: "residentemergencyEvacuation1", id2: "caregiveremergencyEvacuation2"},
      {label: "Assistive devices", id: "residentemergencydevice1", span: true},
      {label: "Equipment/supplies", id: "residentemergencyEquipment1", span: true}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemEmergencyDetails = this.initialDetails;
    }
  }
}
