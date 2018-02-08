import {Component, Input, Output, EventEmitter, OnInit} from '@angular/core';

@Component({
  selector: 'synkwise-facility-list',
  templateUrl: 'facility-list.component.html',
  styleUrls: ['facility-list.component.css']
})
export class FacilityListComponent implements OnInit {
  @Input() facilities: Array<any>;

  constructor() {

  }

  ngOnInit() {

  }

}
