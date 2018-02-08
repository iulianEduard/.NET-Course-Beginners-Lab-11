/**
 * Created by coprita on 11/30/2017.
 */
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {ApiService} from "../../../shared/services/api.service/api.service";


@Injectable()
export class ResidentService {

  constructor(private apiService: ApiService) {
  }

  get(id: number) {
    return this.apiService.get('/api/Resident/' + id);
  }

  createResident(residentItem: any) {
    let urlCreate: string = '/api/Resident/Save';
    return this.apiService.post(urlCreate, residentItem);
  }

  updateResident(residentItem: any, id: number) {
    return this.apiService.put('/api/resident/'+id, residentItem);
  }

  inactivateResident(id: number) {
    return this.apiService.post('/api/resident/activate/'+id, null);
  }

  getFacilityResidents(facilityId: number) {
    let urlProviders = '/api/resident/facilities/' + facilityId;
    return this.apiService.get(urlProviders);
  }

  getResidentList() {
    var residentList = [];
    residentList.push({
      id: 1,
      name: 'Resident Rares',
      description: "HILLARY's Resident Assessment was Modified at 10/22/2017 9:02:21 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/557426_461475487207910_1051258564_n.jpg?oh=b673aaff310e9a159ead20daba75e1bf&oe=5AD68E8A'
    });
    residentList.push({
      id: 2,
      name: 'Rares Felecan',
      description: "Test patient's Profile was Added at 10/22/2017 4:40:31 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
    });
    residentList.push({
      id: 3,
      name: 'Cosmin',
      description: "Mr. MIYAGI's Resident CarePlan was Modified at 10/4/2017 9:37:07 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
    });
    residentList.push({
      id: 2,
      name: 'Rares Felecan',
      description: "Test patient's Profile was Added at 10/22/2017 4:40:31 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
    });
    residentList.push({
      id: 3,
      name: 'Cosmin',
      description: "Mr. MIYAGI's Resident CarePlan was Modified at 10/4/2017 9:37:07 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
    });
    residentList.push({
      id: 2,
      name: 'Rares Felecan',
      description: "Test patient's Profile was Added at 10/22/2017 4:40:31 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
    });
    residentList.push({
      id: 3,
      name: 'Cosmin',
      description: "Mr. MIYAGI's Resident CarePlan was Modified at 10/4/2017 9:37:07 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
    });
    residentList.push({
      id: 2,
      name: 'Rares Felecan',
      description: "Test patient's Profile was Added at 10/22/2017 4:40:31 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
    });
    residentList.push({
      id: 3,
      name: 'Cosmin',
      description: "Mr. MIYAGI's Resident CarePlan was Modified at 10/4/2017 9:37:07 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
    });
    return residentList;
  }

  getAllFacitilies(gridParam: any, providerId: number) {
    let urlProviders = '/api/providers/' + providerId + '/facilities';
    return this.apiService.getWithParam(urlProviders, gridParam);
  }
}

