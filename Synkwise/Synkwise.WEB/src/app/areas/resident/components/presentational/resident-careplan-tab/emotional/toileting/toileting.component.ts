/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-toileting',
  templateUrl: 'toileting.component.html',
  styleUrls: ['toileting.component.css']
})
export class CareplanToiletingComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemToiletingDetails: any;

  ngOnInit() {
    this.itemToiletingDetails = [{label: "Ability to get to and from the toilet", id1:"toiletingInput1", id2:"toiletingInput2"},
      {label: "Ability to get on and off the toilet", id1: "residentAbility1", id2: "residentAbility2"},
      {label: "Ability to cleanse afterwards", id1: "residenttoiletingAbility1", id2: "residenttoiletingAbility2"},
      {label: "Ability to adjust clothing", id1: "residenttoiletingClothing1", id2: "residenttoiletingClothing2"},
      {label: "Other", id1: "residenttoiletingOther1", id2: "residenttoiletingOther2"},
      {label: "Allergies to toileting supplies", id1: "residenttoiletingAllergie1", id2: "residenttoiletingAllergie2"},
      {label: "Assistive devices", id: "residenttoiletingDevices", span:true},
      {label: "Equipment/supplies", id: "residenttoiletingEquip", span:true},
      {label: "Consultation, teaching, delegation and/or assessment", id: "residenttoiletingConsult", span:true},
      {label: "Caregiver’s time spent", id1: "residenttoiletingTime1", id2: "residenttoiletingTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemToiletingDetails = this.initialDetails;
    }
  }
}
