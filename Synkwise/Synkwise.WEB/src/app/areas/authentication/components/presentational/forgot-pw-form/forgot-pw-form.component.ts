import { Component, ChangeDetectionStrategy, OnInit, Output, Input, EventEmitter} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {EmailValidator} from "../../../../../shared/validators/email.validator";

@Component({
    selector: 'forgotpw-form',
    templateUrl: 'forgot-pw-form.component.html',
    styleUrls: ['forgot-pw-form.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ForgotPwFormComponent implements OnInit {
   @Output() forgotPassword = new EventEmitter<any>();

    form: FormGroup;

    ngOnInit() {
        this.form = new FormGroup({
            email: new FormControl('', [Validators.required, EmailValidator.isValid])
        });
    }

    onSubmit({value, valid}: { value: any, valid: boolean }) {
        if (valid) {
            this.forgotPassword.emit(value);
        }
    }
}
