/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';
import {Constants} from "../../../../../../shared/utils";

@Component({
  selector: 'synkwise-resident-careplan-initial',
  templateUrl: 'initial.component.html',
  styleUrls: ['initial.component.css']
})
export class InitialCareplanComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemInitialDetails: any;

  ngOnInit() {
    this.itemInitialDetails = {initialDate: Constants.formatDateToUS(null)};
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemInitialDetails = this.initialDetails;
    }
  }

  setDateInitialPlan(value) {

  }
}
