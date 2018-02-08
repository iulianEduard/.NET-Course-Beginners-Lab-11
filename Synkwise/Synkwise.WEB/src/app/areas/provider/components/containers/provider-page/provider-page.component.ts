import { Component } from '@angular/core';
import {ProviderService} from '../../../services/provider.service';

@Component({
  selector: 'synkwise-provider-page',
  templateUrl: 'provider-page.component.html',
  styleUrls: ['provider-page.component.css']
})
export class ProviderPageComponent {
  facilityAlerts: Array<any> = [];
  residentAlerts: Array<any> = [];
  staffAlerts: Array<any> = [];

constructor(private residentService: ProviderService) {
  this.facilityAlerts.push({
    id: 1,
    name: 'Seaside Home',
    description: 'The document x for this home needs renewal'
  });
  this.facilityAlerts.push({
    id: 2,
    name: 'Hillside Residence',
    description: 'The document y for this home needs renewal'
   });
  this.facilityAlerts.push({
    id: 3,
    name: 'Lakeside Home',
    description: 'The document z for this home needs renewal'
  });
  this.residentAlerts.push({
    id: 1,
    name: 'Cosmin Oprita',
    description: 'The agreement x needs renewal'
  });
  this.residentAlerts.push({
    id: 2,
    name: 'Cosmin',
    description: 'The care plan needs to be modified'
  });
  this.staffAlerts.push({
    id: 1,
    name: 'Mihai',
    description: 'The employment contract needs renewal'
  });
  this.staffAlerts.push({
    id: 2,
    name: 'Razvan',
    description: 'The employment contract needs renewal'
  });
}
}
