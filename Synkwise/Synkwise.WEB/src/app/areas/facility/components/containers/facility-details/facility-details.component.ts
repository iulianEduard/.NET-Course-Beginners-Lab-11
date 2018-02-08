import {Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FacilityService } from '../../../services/facility.service/facility.service';

@Component({
  selector: 'synkwise-facility-details',
  templateUrl: 'facility-details.component.html',
  styleUrls: ['facility-details.component.css']
})
export class FacilityDetailsComponent implements OnInit {

 // facilityId: number;
 // facilityData: any;

  constructor(private route: ActivatedRoute, private facilityService: FacilityService, private router: Router) {

  }

  ngOnInit() {
   /* this.facilityId = this.route.snapshot.queryParams['id'];

    if (this.facilityId)
    {
      // GET DATA FROM SERVER
      // this.facilityData = this.facilityService.getFacilityById(this.facilityId);
    } */
  }

  save(entity: any) {
   // debugger;
    // SEND DATA TO SERVER
    // this.facilityService.saveFacility(entity);
   // this.router.navigateByUrl('/facility/list');
  }
}
