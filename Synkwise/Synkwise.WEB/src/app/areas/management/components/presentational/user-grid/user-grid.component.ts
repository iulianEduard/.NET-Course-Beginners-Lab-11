import {Component, Input, Output, EventEmitter, OnInit} from '@angular/core';

@Component({
  selector: 'synkwise-user-grid',
  templateUrl: 'user-grid.component.html',
  styleUrls: ['user-grid.component.css']
})
export class UserGridComponent implements OnInit {
  @Input() facilities: Array<any>;

  constructor() {

  }

  ngOnInit() {

  }

}
