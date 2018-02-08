/**
 * Created by coprita on 12/2/2017.
 */
import {Injectable} from '@angular/core';

@Injectable()
export class CommonService {

  findItemInComplexArray(item, array, property): number {
    //return position in array
    var result = -1;
    if (item && array && property) {
      array.forEach(function (el, idx) {
        if (Number(item) && el[property] && el[property] == item) {
          result = idx;
        }
        if ((typeof item === 'boolean') && el[property] && el[property] == item) {
          result = idx;
        }
        else if (el[property] && !Number(el[property]) && el[property].toLowerCase() == item.toLowerCase())
          result = idx;
      });
    }

    return result;
  }
}
