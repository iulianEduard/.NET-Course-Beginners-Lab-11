/**
 * Created by coprita on 11/30/2017.
 */
import {Component, Input, OnInit, ElementRef} from '@angular/core';
declare var jQuery: any;

@Component({
  selector: 'synkwise-resident-details-tabs',
  templateUrl: 'resident-details-tabs.component.html',
  styleUrls: ['resident-details-tabs.component.css']
})
export class ResidentDetailsTabsComponent implements OnInit {
  @Input() residentProfile: any;

  constructor(private el: ElementRef) {

  }

  ngOnInit() {
    jQuery(this.el.nativeElement).find('ul.tabs').tabs();
    // jQuery.ready(function(){
    //   jQuery('ul.tabs').tabs();
    // });
  }
}
