import {Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges} from '@angular/core';
import {ManagementService} from "../../../services/management.service/management.service";
import {PagerService} from "../../../../../shared/services/table.service/pager.service";
import {ToasterService} from "angular2-toaster";
import {Constants} from "../../../../../shared/utils";

@Component({
  selector: 'synkwise-invitation-grid',
  templateUrl: 'invitation-grid.component.html',
  styleUrls: ['invitation-grid.component.css']
})
export class InvitationGridComponent implements OnInit {
  gridData: Array<any> = [];
  gridParam: any = {};
  gridTotalCount: number = 0;

  // pager object
  pager: any = {};

  constructor(private pagerService: PagerService, private managementService: ManagementService,
              private toasterService: ToasterService) {
    this.gridParam = this.pagerService.gridPagination;
    this.gridParam.sortColumn = "ID";
  }

  ngOnInit() {
    this.setPage(1);
  }

  getInvitationsData() {
    this.managementService.getAllInvitation(this.gridParam).subscribe(result => {
      if (result.status == 200) {
        this.gridData = result.message.model;
        this.gridTotalCount = result.message.totalCount;
      }
      else {
        this.gridData = [];
        this.gridTotalCount = 0;
      }

      this.pager = this.pagerService.getPager(this.gridTotalCount, this.gridParam.pageNumber);
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }

  setPage(page: number) {
    this.gridParam.pageNumber = page;

    if (page < 1 || (this.pager.totalPages && page > this.pager.totalPages)) {
      return;
    }
    this.getInvitationsData();
  }

  setSortOrder(sortColumn) {
    this.gridParam.sortColumn = sortColumn;
    this.gridParam.sortDirection = this.gridParam.sortDirection === 'Asc' ? 'Desc' : 'Asc';

    this.getInvitationsData();
  }

  setSearch(searchItem) {
    if (searchItem.value === '' || !searchItem.value) {
      this.gridParam.pageNumber = 1;
      delete this.gridParam[searchItem.column];
    } else {
      this.gridParam.pageNumber = 1;
      this.gridParam[searchItem.column] = searchItem.value;
    }
    this.getInvitationsData();
  }

  checkInvitationStatus(invitationDate):boolean{
    var result = true;

    if (Constants.addDaysToDate(Constants.NumberOfDaysInvitationExpired, new Date(invitationDate)) < new Date())
      result = false;
    return result;
  }
}
