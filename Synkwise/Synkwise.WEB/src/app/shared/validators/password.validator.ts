/**
 * Created by coprita on 11/25/2017.
 */
import {FormControl} from '@angular/forms';
import {Constants} from "../utils";

export class PasswordValidator {
  static isValid(control: FormControl) {
    if (control.value && (control.value.length <= 5 || !Constants.PASSWORDREGEX.test(control.value))) {
      return {"notValid": true};
    }

    return null;
  }
}
