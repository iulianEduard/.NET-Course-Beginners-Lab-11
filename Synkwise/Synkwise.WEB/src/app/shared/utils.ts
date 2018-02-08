/**
 * Created by coprita on 11/25/2017.
 */
export class Constants {
  // public static PASSWORDREGEX = /^(?=.*[A-Z])(^[a-zA-Z0-9])[a-zA-Z0-9$-/:-?{-~!"^_`[\]@#](?=.*[0-9])(?=.*[$@`!%*?&]){7,}$/;  //letters and numeric
  public static PASSWORDREGEX = /(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@`~!%*?&#()^{}]){7,}/;  //letters and numeric
  public static EMAIL_REGEXP = /^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i;
  public static PHONE_MASK = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
  public static HEIGHT_MASK = [/[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];
  public static NumberOfDaysInvitationExpired = 1;
  public static addDaysToDate = addDaysToDate;
  public static formatDateToUS = formatDateToUS;
}

function addDaysToDate(n, date) {
  var dateTime = date != undefined ? date : new Date();
  var time = dateTime.getTime();
  var changedDate = new Date(time + (n * 24 * 60 * 60 * 1000));
  dateTime.setTime(changedDate.getTime());
  return dateTime;
}

function formatDateToUS(date){
  var dateTime = date != undefined ? date : new Date().toISOString();
  var result = new Date(dateTime).toLocaleString().split(',')[0];

  return result;
}
