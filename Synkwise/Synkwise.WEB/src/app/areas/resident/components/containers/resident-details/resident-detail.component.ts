import {Component, OnInit, ChangeDetectionStrategy} from '@angular/core';
import {ResidentService} from "../../../services/resident.service";
import {ActivatedRoute} from "@angular/router";
import {CommonService} from "../../../../../shared/services/common.service/common.service";
import {ToasterService} from "angular2-toaster";

@Component({
  selector: 'synkwise-resident-detail',
  templateUrl: 'resident-detail.component.html',
  styleUrls: ['resident-detail.component.css'],
})
export class ResidentDetailComponent implements OnInit {
  residentDetails: any;
  residentList: Array<any> = [];
  residentId: any = 0;

  constructor(private residentService: ResidentService, private activatedRoute: ActivatedRoute,
              private commonService: CommonService, private toasterService: ToasterService) {
  }

  ngOnInit() {
    this.residentId = this.residentId === 0 ? this.activatedRoute.snapshot.paramMap.get('id') : this.residentId;
    this.getResidentList();

    this.getResident(this.residentId);
  }

  getResident(id: number): void {
    this.residentService.get(id).subscribe(result => {
      if (result.status == 200) {
        this.residentDetails = result.message.model;
      }
      else {
        this.toasterService.pop('info', 'Resident details', "Invalid resident id");
      }
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }

  residentChanged(residentId: number): void {
    this.residentId = residentId;
    this.ngOnInit();
  }

  getResidentList(): void {
    // this.residentList = this.residentService.getResidentList();
    this.residentService.getFacilityResidents(1).subscribe(result => {
      if (result.status == 200) {
        this.residentList = result.message.model;
      }
      else {
        this.residentList = [];
        this.toasterService.pop('info', 'Facility residents', "No data for found");
      }
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }

  inactivateResident(id: number) {
    var activationMessage = this.residentDetails.statusID == 1 ? "Resident was successfully deactivated" : "Resident was successfully activated";
    this.residentService.inactivateResident(id).subscribe(result => {
      if (result.status == 200) {
        this.toasterService.pop('success', 'Resident deactivation', activationMessage);
        this.getResident(id);
      }
      else {
        this.toasterService.pop('info', 'Resident deactivation', "An error occured");
      }
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }
}
