/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-behaviour',
  templateUrl: 'behaviour.component.html',
  styleUrls: ['behaviour.component.css']
})
export class CareplanBehavoiurComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemBehavoiurDetails: any;
  private itemBehaviourChallenging: any;

  ngOnInit() {
    this.itemBehavoiurDetails = [{label: "Usual demeanor/mood", id1: "awarenessInput1", id2: "awarenessInput2"},
      {label: "Handles change in routine", id1: "residentawarenessTrig1", id2: "caregiverawarenessTrig2"},
      {label: "Injury to self, others or property", id1: "residentAwareTrig1", id2: "caregiverAwareTrig2"},
      {label: "Challenging behaviors", id1: "residentAwareOther1", id2: "caregiverAwareOther2"},
      {label: "Aware of “triggers”", id1: "residentAwareOther1", id2: "caregiverAwareOther2"},
      {label: "Handles stressful situations", id1: "residentAwareOther1", id2: "caregiverAwareOther2"},
      {label: "Makes appropriate decisions", id1: "residentAwareOther1", id2: "caregiverAwareOther2"},
      {label: "Resists care/services", id1: "residentAwareOther1", id2: "caregiverAwareOther2"},
      {label: "Distractible/mind wanders", id1: "residentAwareOther1", id2: "caregiverAwareOther2"}];

    this.itemBehaviourChallenging = [{id1: "freeInput11", id2: "freeInput12", id3: "freeInput13"},
      {id1: "freeInput21", id2: "freeInput22", id3: "freeInput23"},
      {id1: "freeInput31", id2: "freeInput32", id3: "freeInput33"},
      {id1: "freeInput41", id2: "freeInput42", id3: "freeInput43"}]
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemBehavoiurDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
