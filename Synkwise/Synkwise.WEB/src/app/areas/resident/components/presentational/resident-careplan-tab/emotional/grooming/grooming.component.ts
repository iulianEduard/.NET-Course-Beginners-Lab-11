/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-grooming',
  templateUrl: 'grooming.component.html',
  styleUrls: ['grooming.component.css']
})
export class CareplanGroomingComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemGroomingDetails: any;

  ngOnInit() {
    this.itemGroomingDetails = [{label: "Combing/brushing hair frequency", id1:"groomingInput1", id2:"groomingInput2"},
      {label: "Makeup preferences", id1: "residentMakeup1", id2: "residentMakeup2"},
      {label: "Nail care", id1: "residentgroomingNail1", id2: "residentgroomingNail2"},
      {label: "Skin care", id1: "residentgroomingSkin1", id2: "residentgroomingSkin2"},
      {label: "Foot care", id1: "residentgroomingFoot1", id2: "residentgroomingFoot2"},
      {label: "Ear care", id1: "residentgroomingEar1", id2: "resi2entgroomingEar1"},
      {label: "Barber/hairdresser", id1: "residentgroominghair1", id2: "residentgroominghair2"},
      {label: "Allergies to grooming supplies", id1: "residentgroomingAllergies1", id2: "residentgroomingAllergies2"},
      {label: "Assistive devices", id: "residentgroomingAssist", span:true},
      {label: "Equipment/supplies", id: "residentgroomingEquip", span:true},
      {label: "Consultation, teaching, delegation and/or assessment", id: "residentgroomingConsult", span:true},
      {label: "Caregiver’s time spent", id1: "residentgroomingTime1", id2: "residentgroomingTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemGroomingDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
