/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-eating',
  templateUrl: 'eating.component.html',
  styleUrls: ['eating.component.css']
})
export class CareplanEatingComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemEatingDetails: any;

  ngOnInit() {
    this.itemEatingDetails = [{label: "Ability to feed self", id1:"eatingInput1", id2:"eatingInput2"},
      {label: "Ability to swallow	", id1: "residentAbility1", id2: "residentAbility2"},
      {label: "Special diet", id1: "residenteatingDiet1", id2: "residenteatingDiet2"},
      {label: "Supplemental nutrition", id1: "residenteatingNutrition1", id2: "residenteatingNutrition2"},
      {label: "Allergies to food", id1: "residenteatingFoot1", id2: "residenteatingFoot2"},
      {label: "Assistive devices", id: "residenteatingAssist", span:true},
      {label: "Equipment/supplies", id: "residenteatingEquip", span:true},
      {label: "Consultation, teaching, delegation and/or assessment", id: "residenteatingConsult", span:true},
      {label: "Foods/beverage likes", id: "residenteatingAssist", span:true},
      {label: "Caregiver’s time spent", id1: "residenteatingTime1", id2: "residenteatingTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemEatingDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
