/**
 * Created by coprita on 11/30/2017.
 */
import {
  Component, Input, OnInit, SimpleChanges, OnChanges, Output, EventEmitter,
  ChangeDetectionStrategy
} from '@angular/core';
import {Observable} from "rxjs";

@Component({
  selector: 'synkwise-resident-details',
  templateUrl: 'resident-details.component.html',
  styleUrls: ['resident-details.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResidentDetailsComponent implements OnInit, OnChanges {
  @Output() activate = new EventEmitter<any>();
  @Input() residentDetails: any = { contact: {}};

  ngOnInit() {
  }

  inactivateResident(id: number) {
    this.activate.emit(id);
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['residentDetails']) {
      var resident = changes['residentDetails'].currentValue;

      if (resident) {
        this.residentDetails = resident;
      }
    }
  }
}
