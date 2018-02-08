import { FormControl } from '@angular/forms';

export class PhoneValidator {
    static isValid(control: FormControl) {
        var PHONE_REGEXP = /^([()\- x+]*\d[()\- x+]*){4,16}$/;

        if (control.value && (control.value.length <= 5 || !PHONE_REGEXP.test(control.value))) {
            return { "notPhone": true };
        }

        return null;
    }
}