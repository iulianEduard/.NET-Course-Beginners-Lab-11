import {
  Component, ChangeDetectionStrategy, OnInit, Output, EventEmitter, Input, OnChanges,
  SimpleChanges
} from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms';
import {EmailValidator} from "../../../../../shared/validators/email.validator";
import {RoleModel} from "../../../../../shared/models/common/roleModel";
import {MaterializeAction} from "angular2-materialize/dist";
declare var Materialize: any;

@Component({
  selector: 'synkwise-invitation-create-form',
  templateUrl: 'invitation-create-form.component.html',
  styleUrls: ['invitation-create-form.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InvitationCreateFromComponent implements OnInit, OnChanges {
  @Output() sendInvitation = new EventEmitter<any>();
  @Output() editInvitation = new EventEmitter<any>();
  @Input() invitationForEdit: any;
  @Input() roleList: Array<RoleModel>;
  invitationModel: FormGroup;

  constructor() {
  }

  ngOnInit() {
    this.invitationModel = new FormGroup({
      emailTo: new FormControl('', [Validators.required, EmailValidator.isValid]),
      roleId: new FormControl('', [Validators.required]),
      id: new FormControl(0, [])
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['invitationForEdit'] && this.invitationForEdit) {
      if (this.invitationForEdit.id) {
        this.invitationModel.controls["id"].setValue(this.invitationForEdit.id);
      }

      if (this.invitationForEdit.emailTo) {
        this.invitationModel.controls["emailTo"].setValue(this.invitationForEdit.emailTo);
      }

      if (this.invitationForEdit.emailTo) {
        this.invitationModel.controls["roleId"].setValue(this.invitationForEdit.roleId);
      }

      Materialize.updateTextFields();
    }
  }

  onSubmit({value, valid}: { value: any, valid: boolean }) {
    if (valid) {
      value.providerId = 1;
      if (value.id > 0)
        this.editInvitation.emit(value);
      else {
        delete value["id"];
        this.sendInvitation.emit(value);
      }
    } else {
      return;
    }
  }
}
