import {Component, OnInit} from '@angular/core';
import {ManagementService} from "../../../services/management.service/management.service";
import {ToasterService} from "angular2-toaster";
import {Router, ActivatedRoute, Params} from "@angular/router";
import {RoleModel} from "../../../../../shared/models/common/roleModel";
import {Observable} from "rxjs";

@Component({
  templateUrl: 'invitation-page.component.html',
  styleUrls: ['invitation-page.component.css']
})
export class InvitationPageComponent implements OnInit {
  facilities: Array<any> = [];
  invitationID: number;
  invitationModel: any;
  roleList: Array<RoleModel>;

  constructor(private managementService: ManagementService, private toasterService: ToasterService,
              private  router: Router, private route: ActivatedRoute) {
    this.getRoleList();
  }

  ngOnInit() {
    this.route.queryParams.subscribe((params: Params) => {
      this.invitationID = params['id'];
    });

    if (this.invitationID)
      this.getInvitationForEdit(this.invitationID);
  }

  getInvitationForEdit(id: number): void {
    this.managementService.get(id).subscribe(result => {
      if (result.status == 200) {
        this.invitationModel = result.message.model;
      }
      else {
        this.toasterService.pop('info', 'invitation', "Invalid invitation id");
      }
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }

  sendInvitation(invitationModel): void {
    this.managementService.sendInvitation(invitationModel).subscribe(result => {
      if (result.status == 200) {
        this.toasterService.pop('success', 'Send invitation', "Data saved successfully.");
        this.router.navigateByUrl('/management/home');
      }
      else {
        this.toasterService.pop('info', 'Send invitation', result.message.error);
      }
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }

  editInvitation(invitationModel): void {
    this.managementService.updateInvitation(invitationModel, invitationModel.id).subscribe(result => {
      if (result.status == 200) {
        this.toasterService.pop('success', 'Send invitation', "Data saved successfully.");
        this.router.navigateByUrl('/management/home');
      }
      else {
        this.toasterService.pop('info', 'Send invitation', result.message.error);
      }
    }, (error: Error) => {
      if (JSON.parse(error.message)) {
        var errorObject = JSON.parse(error.message);
        this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
      }
      else this.toasterService.pop('error', 'Error', "Connection Error");
    });
  }

  getRoleList(): void {
    this.managementService.getRoles().subscribe(result => {
      if (result.status == 200) {
        this.roleList = result.message as Array<RoleModel>;
      }
      else {
        this.toasterService.pop('info', 'Get Roles', result.message.error);
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
