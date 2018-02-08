/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-interventions',
  templateUrl: 'interventions.component.html',
  styleUrls: ['interventions.component.css']
})
export class CareplanInterventionsComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemInterventionsDetails: any;
  private pleaseList: any;

  ngOnInit() {
    this.itemInterventionsDetails = [
      {label: "Behavioral care plan", id1: "interventionPlan1", id2: "interventionPlan2"},
      {label: "Orders/delegations", id1: "in2erventionOrder1", id2: "interventionOrder1"}];

    this.pleaseList = [
      {label: "Assistive devices", model: "assistanceDevice", id: "personalPLAssistID", span: true},
      {label: "Equipment/assistive devices installed", model: "equipment", id: "personalPLEquipID", span: true},
      {label: "Other", model: "interventionsOther", id:"other1", span: true}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemInterventionsDetails = this.initialDetails;
    }
  }
}
