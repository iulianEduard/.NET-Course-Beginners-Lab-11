/**
 * Created by coprita on 11/30/2017.
 */
import {
  Component, Input, ElementRef, ViewChild, OnInit, Output, EventEmitter, OnChanges,
  SimpleChanges
} from '@angular/core';

import {ActivatedRoute, ParamMap, Router} from "@angular/router";
import {debug} from "util";
import {Observable} from "rxjs";
import {ResidentService} from "../../../services/resident.service";
declare var jQuery: any;

@Component({
  selector: 'synkwise-resident-list-form',
  templateUrl: 'resident-list-form.component.html',
  styleUrls: ['resident-list-form.component.css']
})
export class ResidentListFormComponent implements OnInit {
  @Output() residentChanged = new EventEmitter<any>();
  @Input() residentList: Array<any> = [];
  private hideLeftBtn: boolean = true;
  private hideRightBtn: boolean = false;

  private itemsLength = 0;
  itemSize: any = 0;
  menuWrapperSize: any = 0;
  private indexCarrousel: number = 0;
  private showNextItemsNumber = 3;

  getMenuMaxSize = function () {
    return this.itemsLength * this.itemSize;
  };

  constructor(private residentService: ResidentService, private route: ActivatedRoute, private router: Router) {
    // this.residentList =  this.residentService.getResidentList();
  }

  ngOnInit() {
    this.itemsLength = this.residentList.length;
  }

  goToResident(residendId: number) {
    this.router.navigate(['/resident/details', residendId]);
    this.residentChanged.emit(residendId);
  }

  public nextItem(): void {
    if (this.itemSize === 0)
      this.createDynamicVariable(1);

    var visibleItems = parseInt((this.menuWrapperSize / this.itemSize).toString());

    this.indexCarrousel = (visibleItems + this.indexCarrousel + this.showNextItemsNumber) >= this.itemsLength
                            ? this.itemsLength : (this.indexCarrousel + this.showNextItemsNumber);
    var goNext = this.indexCarrousel > visibleItems ? this.indexCarrousel - visibleItems : this.indexCarrousel;
    jQuery('.menu').animate({scrollLeft: this.itemSize * goNext }, 1000);

    this.createDynamicVariable(1);
  }

  public previousItem(): void {
    var visibleItems = parseInt((this.menuWrapperSize / this.itemSize).toString());

    this.indexCarrousel = (this.indexCarrousel - visibleItems - this.showNextItemsNumber) <= 0
                      ? 0 : (this.indexCarrousel - this.showNextItemsNumber - visibleItems);
    jQuery('.menu').animate({scrollLeft: this.itemSize * this.indexCarrousel}, 1000);
    this.createDynamicVariable(2);
  }

  private createDynamicVariable(direction: number) {
    this.itemsLength = this.residentList.length;
    this.itemSize = jQuery('.item').outerWidth(true);
    this.menuWrapperSize = jQuery('.menu-wrapper').outerWidth();

    //if displayed items are less than total
    var visibleItems = parseInt((this.menuWrapperSize / this.itemSize).toString());
    if (direction == 1 && (visibleItems + this.showNextItemsNumber) > this.itemsLength) {
      this.hideRightBtn = false;
      this.hideLeftBtn = true;
      return;
    }


    // if ((this.menuWrapperSize / 100) > this.itemsLength)
    //   return;

    // show/hide next-previous buttons
    if (this.indexCarrousel === 0) {
      this.hideLeftBtn = true;
      this.hideRightBtn = false;
    }
    // show both paddles in the middle
    else if (this.indexCarrousel > 0 && (this.showNextItemsNumber + this.indexCarrousel) < this.itemsLength) {
      this.hideLeftBtn = false;
      this.hideRightBtn = false;
    }
    else if ((this.showNextItemsNumber + this.indexCarrousel) >= this.itemsLength) {
      this.hideLeftBtn = false;
      this.hideRightBtn = true;
    }
  }
}
