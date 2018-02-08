/**
 * Created by coprita on 11/30/2017.
 */
import {Component, Input, OnInit} from '@angular/core';


@Component({
  selector: 'synkwise-resident-home',
  templateUrl: 'resident-home.component.html',
  styleUrls: ['resident-home.component.css']
})
export class ResidentHomeComponent implements OnInit {
  @Input() recentActivity: Array<any>;

  constructor() {

  }

  ngOnInit() {

  }
}
