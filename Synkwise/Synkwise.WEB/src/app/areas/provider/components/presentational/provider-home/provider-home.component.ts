import {Component, Input, Output, EventEmitter, OnInit} from '@angular/core';

@Component({
  selector: 'synkwise-provider-home',
  templateUrl: 'provider-home.component.html',
  styleUrls: ['./provider-home.component.css']
})
export class ProviderHomeComponent implements OnInit {
  @Input() facilityAlerts: Array<any>;
  @Input() residentAlerts: Array<any>;
  @Input() staffAlerts: Array<any>;

  constructor() {

  }

  ngOnInit() {

  }

}
