/**
 * Created by coprita on 12/5/2017.
 */
import {Component, Inject} from '@angular/core';
import {Router, ActivatedRoute, Params} from '@angular/router';

import {ToasterService} from "angular2-toaster";
import {ResidentService} from "../../../services/resident.service";
import {PagerService} from "../../../../../shared/services/table.service/pager.service";

@Component({
  templateUrl: 'resident-create.component.html'
  // styleUrls: ['resident-create.component.css']
})
export class ResidentCreateComponent {
  gridParam: any = {};
  facilityList: Array<any> = [];
  residentID: number = 0;
  residentForEdit: any = {};

  constructor(private residentService: ResidentService, private router: Router,
              private toasterService: ToasterService, private pagerService: PagerService,
              private route: ActivatedRoute) {
    this.gridParam = this.pagerService.gridPagination;
    this.gridParam.pageSize = 200;
    this.gridParam.pageNumber = 1;
    this.getAllFacilities();

    this.route.queryParams.subscribe((params: Params) => {
      this.residentID = params['id'];
    });

    if (this.residentID)
      this.getResidentForEdit(this.residentID);
  }

  createResident(residentItem: any): void {
    //update resident
    if (residentItem.id > 0){
      this.residentService.updateResident(this.prepareParamForResident(residentItem), residentItem.id).subscribe(result => {
        this.toasterService.pop('success', 'Update resident', "Data successfully saved.");
        this.router.navigateByUrl('/resident/details/'+residentItem.id);
      }, (error: Error) => {
        if (JSON.parse(error.message)) {
          var errorObject = JSON.parse(error.message);
          this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
        }
      });
    }
    else //save new
    {
      residentItem.id = 0;
      residentItem.contactID = 0;
      residentItem.statusID = 1;
      this.residentService.createResident(this.prepareParamForResident(residentItem)).subscribe(result => {
        this.toasterService.pop('success', 'Create resident', "Data successfully saved.");
        this.router.navigateByUrl('/resident/home');
      }, (error: Error) => {
        if (JSON.parse(error.message)) {
          var errorObject = JSON.parse(error.message);
          this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
        }
      });
    }
  }

  getAllFacilities(): any {
    this.residentService.getAllFacitilies(this.gridParam, 1).subscribe(result => {
      if (result.data) {
        this.facilityList = result.data;
      }
      else {
        this.toasterService.pop('info', 'Get Providers', "No data for providers");
      }
    });
  }

  getResidentForEdit(id: number){
    this.residentService.get(id).subscribe(result => {
      if (result.status == 200) {
        this.residentForEdit = result.message.model;
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

  //private methods
  prepareParamForResident(residentItem) {
    var contactItem = {
      id: residentItem.contactID,
      firstName: residentItem.firstName,
      lastName: residentItem.lastName,
      address: residentItem.address,
      state: residentItem.state,
      stateID: 0,
      phone: residentItem.phone,
      zipCode: residentItem.zipCode,
      city: residentItem.city
    };

    residentItem.Contact = contactItem;

    delete residentItem.firstName;
    delete residentItem.lastName;
    delete residentItem.address;
    delete residentItem.state;
    delete residentItem.phone;
    delete residentItem.zipCode;
    delete residentItem.city;

    return residentItem;
  }
}
