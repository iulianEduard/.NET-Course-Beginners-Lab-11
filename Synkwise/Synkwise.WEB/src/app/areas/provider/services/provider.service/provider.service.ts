import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from '../../../../shared/services/api.service';

@Injectable()
export class ProviderService {

  constructor(private apiService: ApiService) { }

  getForecast() {
    return this.apiService.get('/api/SampleData/WeatherForecasts');
  }

  getProvider() {
    return this.apiService.get('api/Provider/1');
  }

  saveProvider(entity: any) {
    return this.apiService.post('api/Provider/', entity);
  }

  getProviderById(id: any) {
       return this.apiService.getWithParam('/api/Provider/', id);
  }
  // saveUserProfile(userProfile, userId) {
  //  return this.apiService.post('api/profile/accounts/'+userId+'/profile', userProfile);
  // }
}
