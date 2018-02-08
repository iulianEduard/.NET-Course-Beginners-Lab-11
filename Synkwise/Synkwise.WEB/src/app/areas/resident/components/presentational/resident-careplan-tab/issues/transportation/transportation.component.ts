/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-transportation',
  templateUrl: 'transportation.component.html',
  styleUrls: ['transportation.component.css']
})
export class CareplanTransportationComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemTransportationDetails: any;

  ngOnInit() {
    this.itemTransportationDetails = [{label: "Resources", id1:"transportationInput1", id2:"transportationInput2"},
      {label: "Ability to get in and out of a vehicle", id1: "residenttransportation1", id2: "caregivertransportation"},
      {label: "Assistance during ride", id1: "residenttransportationRide1", id2: "caregivertransportationRide2"},
      {label: "Assistive devices", id: "residentTransportationdevice1", span: true}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemTransportationDetails = this.initialDetails;
    }
  }
}
