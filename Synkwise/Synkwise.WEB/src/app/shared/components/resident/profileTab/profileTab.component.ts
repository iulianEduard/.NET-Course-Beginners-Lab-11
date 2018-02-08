/**
 * Created by coprita on 1/10/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-user-profiletab',
  templateUrl: 'profileTab.component.html',
  styleUrls: ['profileTab.component.css']
})
export class ProfileTabComponent implements OnInit, OnChanges {
  @Input() profileDetails: any;
  itemProfileDetails: any;

  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['profileDetails'] && this.profileDetails) {
      this.itemProfileDetails = this.profileDetails;
    }
  }
}
