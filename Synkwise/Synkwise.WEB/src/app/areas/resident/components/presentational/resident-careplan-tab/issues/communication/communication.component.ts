/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-communication',
  templateUrl: 'communication.component.html',
  styleUrls: ['communication.component.css']
})
export class CareplanCommunicationComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemCommunicationDetails: any;

  ngOnInit() {
    this.itemCommunicationDetails = [{label: "Language barriers", id1:"communicationInput1", id2:"communicationInput2"},
      {label: "Visual barriers", id1: "residentcommunication1", id2: "caregivercommunication"},
      {label: "Hearing barriers", id1: "residentcommunicationHearing1", id2: "caregivercommunicationHearing2"},

      {label: "Assistive devices", id: "residentCommunicationdevice1", span: true},
      {label: "Equipment/supplies", id: "residentCommunicationEquipment1", span: true},
      {label: "Consultation, teaching, delegation and/or assessment", id: "residentConsulting1", span: true},

      {label: "Caregiver’s time spent", id1: "residentcommunicationTime1", id2: "caregivercommunicationTime2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemCommunicationDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
