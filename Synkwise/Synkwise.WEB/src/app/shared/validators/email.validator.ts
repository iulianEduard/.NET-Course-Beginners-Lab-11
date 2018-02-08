/**
 * Created by coprita on 11/25/2017.
 */
import { FormControl } from '@angular/forms';
import { Constants } from '../utils';

export class EmailValidator {
  static isValid(control: FormControl) {
    if (control.value && (control.value.length <= 5 || !Constants.EMAIL_REGEXP.test(control.value))) {
      return { "notEmail": true };
    }

    return null;
  }
}
