import {Injectable} from '@angular/core';
import {BehaviorSubject} from "rxjs";

@Injectable()
export class ResidentSharedService {
  // Observable boolean sources
  private residentSource = new BehaviorSubject<boolean>(false);

  // Observable boolean streams
  resident$ = this.residentSource.asObservable();

  //resident list for details
  setResidentList(residentValue: boolean) {
    this.residentSource.next(residentValue);
  }

  get isResidentDetails() {
    this.resident$.subscribe({
      next: (v) => console.log('observerA: ' + v)  // output initial value, then new values on `next` triggers
    });
    return this.resident$;
  }
}
