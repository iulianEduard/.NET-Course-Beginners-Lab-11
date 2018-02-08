/**
 * Created by coprita on 12/29/2017.
 */
import {EventEmitter, Component, Output, Input, OnChanges, SimpleChanges, ChangeDetectionStrategy} from "@angular/core";
import {Constants} from "../../utils";
import {StorageService} from "../../services/storage.service/storage.service";
import {IMyDateModel, IMyDpOptions, IMyDate} from "mydatepicker";
declare var jQuery: any;
declare var Materialize: any;

@Component({
  selector: 'synkwise-input-date',
  templateUrl: 'date-input.component.html',
  styleUrls: ['date-input.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class DateInputComponent implements OnChanges {
  @Output() setDateMethod: EventEmitter<any> = new EventEmitter<any>();
  @Input() defaultDate: string;
  @Input() inputName: string;
  private selDate: IMyDate = null;//{year: 0, month: 0, day: 0};

  myDatePickerOptions: IMyDpOptions = {
    // other options...
    // dateFormat: 'dd/mm/yyyy',
    openSelectorOnInputClick: true,
    editableDateField: false,
    openSelectorTopOfInput: true,
    showTodayBtn: true
  };

  constructor(private storageService: StorageService) {
  }

  ngOnInit() {
    // this.$input = jQuery('.customdatepicker').pickadate({
    //   selectMonths: true, // Creates a dropdown to control month
    //   selectYears: 20, // Creates a dropdown of 15 years to control year,
    //   today: 'Today',
    //   firstDay: 1,
    //   //clear: 'Clear',
    //   close: 'Ok',
    //   format: 'dd/mm/yyyy',
    //   closeOnSelect: true, // Close upon selecting a date,
    //   onSet: this.onSet,
    //   onClose: this.close,
    // });
    //
    // this.picker = this.$input.pickadate('picker');
  }


  onDateChanged(event: IMyDateModel) {
    // event properties are: event.date, event.jsdate, event.formatted and event.epoc
    this.defaultDate = event.formatted;
    // this.selDate = event.date;
    this.setDateMethod.emit(this.defaultDate);
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['defaultDate']) {
      if (this.defaultDate) {
        let d: Date = new Date(this.defaultDate);
        this.selDate = {
          year: d.getFullYear(),
          month: d.getMonth() + 1,
          day: d.getDate()
        };
      }

      Materialize.updateTextFields();
    }
  }

  //
  // close() {
  //   this.defaultDate = this.startDate;
  //   localStorage.setItem(this.inputName, this.startDate);
  // }
  //
  // onSet(context) {
  //   jQuery('.customdatepicker').blur();
  //   this.startDate = jQuery('.customdatepicker').pickadate().val();
  //   Materialize.updateTextFields();
  // }
}


