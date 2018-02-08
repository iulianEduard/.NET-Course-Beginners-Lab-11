import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from '../../../../shared/services/api.service';

@Injectable()
export class FacilityService {

  constructor(private apiService: ApiService) { }

  getForecast() {
    return this.apiService.get('/api/SampleData/WeatherForecasts');
  }

  getFacilityById(id: number) {
    return this.apiService.get('api/Facility/GetFacilityById?id=' + id);
  }

  saveFacility(entity: any) {
    return this.apiService.post('api/Facility/SaveFacility', entity);
  }
}
