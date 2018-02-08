/**
 * Created by coprita on 1/13/2018.
 */
import {Component, ElementRef} from '@angular/core';
declare var jQuery: any;

@Component({
  selector: 'synkwise-careplan-edit-form',
  templateUrl: 'resident-careplan-edit-form.component.html',
  styleUrls: ['resident-careplan-edit-form.component.css']
})
export class ResidentCareplanEditFormComponent {
  constructor(private el: ElementRef) {

  }

  ngOnInit() {
    jQuery(this.el.nativeElement).find('ul.tabs').tabs();
    jQuery('.collapsibleBath').collapsible();
  }

}
