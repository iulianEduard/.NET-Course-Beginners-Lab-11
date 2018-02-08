/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-elimination',
  templateUrl: 'elimination.component.html',
  styleUrls: ['elimination.component.css']
})
export class CareplanEliminationComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemEliminationDetails: any;

  ngOnInit() {
    this.itemEliminationDetails = [{label: "Daytime needs", id1:"eliminationInput1", id2:"eliminationInput2"},
      {label: "Nighttime needs", id1: "residentNeeds1", id2: "residentNeeds2"},
      {label: "Other", id1: "residenteliminationOther1", id2: "residenteliminationOther2"},
      {label: "Equipment/supplies", id: "residenteliminationEquip", span:true},
      {label: "Consultation, teaching, delegation and/or assessment", id: "residenteliminationConsult", span:true},
      {label: "Caregiver’s time spent", id1: "residenteliminationTime1", id2: "residenteliminationTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemEliminationDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
