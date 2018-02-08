import { Component } from '@angular/core';
import {FacilityService} from "../../../services/facility.service/facility.service";

@Component({
  selector: 'synkwise-facility-page',
  templateUrl: 'facility-page.component.html',
  styleUrls: ['facility-page.component.css']
})
export class FacilityPageComponent {
  facilities: Array<any> = [];

  constructor(private facilityService: FacilityService) {
    this.facilities.push({
      id: 1,
      name: 'Facility Rares',
      phone: '(342) 432-3423',
      fax: '(342) 432-3423',
      address: 'address',
      city: 'Winston-Salem',
      state: 'NC',
      zipcode: '42342',
      residents: [
        {
          name: 'Eduard Varvara',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/557426_461475487207910_1051258564_n.jpg?oh=b673aaff310e9a159ead20daba75e1bf&oe=5AD68E8A'
        },
        {
          name: 'Rares Felecan',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
        },
        {
          name: 'Cosmin Oprita',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
        }
      ]
    });

    this.facilities.push({
      id: 2,
      name: 'Facility Edi',
      phone: '(342) 432-3423',
      fax: '(342) 432-3423',
      address: 'address',
      city: 'city',
      state: 'state',
      zipcode: '42342',
      residents: [
        {
          name: 'Eduard Varvara',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/557426_461475487207910_1051258564_n.jpg?oh=b673aaff310e9a159ead20daba75e1bf&oe=5AD68E8A'
        },
        {
          name: 'Rares Felecan',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
        },
        {
          name: 'Cosmin Oprita',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
        }
      ]
    });

    this.facilities.push({
      id: 3,
      name: 'Facility Cosmin',
      phone: '(342) 432-3423',
      fax: '(342) 432-3423',
      address: 'address',
      city: 'city',
      state: 'state',
      zipcode: '42342',
      residents: [
        {
          name: 'Eduard Varvara',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/557426_461475487207910_1051258564_n.jpg?oh=b673aaff310e9a159ead20daba75e1bf&oe=5AD68E8A'
        },
        {
          name: 'Rares Felecan',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
        },
        {
          name: 'Cosmin Oprita',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
        }
      ]
    });

    this.facilities.push({
      name: 'Facility Cosmin',
      phone: '(342) 432-3423',
      fax: '(342) 432-3423',
      address: 'address',
      city: 'city',
      state: 'state',
      zipcode: '42342',
      residents: [
        {
          name: 'Eduard Varvara',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/557426_461475487207910_1051258564_n.jpg?oh=b673aaff310e9a159ead20daba75e1bf&oe=5AD68E8A'
        },
        {
          name: 'Rares Felecan',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
        },
        {
          name: 'Cosmin Oprita',
          photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
        }
      ]
    });
  }
}
