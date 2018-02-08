/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-memory',
  templateUrl: 'memory.component.html',
  styleUrls: ['memory.component.css']
})
export class CareplanMemoryComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemMemoryDetails: any;

  ngOnInit() {
    this.itemMemoryDetails = [{label: "Memory", id1:"memoryInput1", id2:"memoryInput2"},
      {label: "Memory aides used", id1: "residentmemory1", id2: "caregivermemory"},
      {label: "Ability to use current information that impacts resident’s health/safety", id1: "residentmemoryAbility1", id2: "caregivermemoryAbility2"},
      {label: "Triggers/interventions", id1: "residentmemoryTrig1", id2: "caregivermemoryTrig2"},
      {label: "Other", id1: "residentmemoryOther1", id2: "caregivermemoryOther2"},
      {label: "Caregiver’s time spent", id1: "residentmemoryTime1", id2: "caregivermemoryTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemMemoryDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
