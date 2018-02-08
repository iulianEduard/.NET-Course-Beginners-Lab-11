import {Component} from '@angular/core';
import {ResidentService} from "../../../services/resident.service";

@Component({
  selector: 'synkwise-resident-page',
  templateUrl: 'resident-page.component.html',
  styleUrls: ['resident-page.component.css']
})
export class ResidentPageComponent {
  recentActivityResidents: Array<any> = [];

  constructor(private residentService: ResidentService) {
    this.recentActivityResidents.push({
      id:1,
      name: 'Resident Rares',
      description: "HILLARY's Resident Assessment was Modified at 10/22/2017 9:02:21 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/557426_461475487207910_1051258564_n.jpg?oh=b673aaff310e9a159ead20daba75e1bf&oe=5AD68E8A'
    });
    this.recentActivityResidents.push({
      id:2,
      name: 'Rares Felecan',
      description: "Test patient's Profile was Added at 10/22/2017 4:40:31 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t31.0-8/10557102_917200668323002_3361450605615831989_o.jpg?oh=09715d41593e00e6bc5519a756dad4b2&oe=5AA46A5E'
    });
    this.recentActivityResidents.push({
      id:3,
      name: 'Cosmin',
      description: "Mr. MIYAGI's Resident CarePlan was Modified at 10/4/2017 9:37:07 AM",
      photo: 'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/14212588_797627103672982_2519718204468831559_n.jpg?oh=41735d79e5a8648930e1f58afa1b12c5&oe=5AD647E7'
    });

  }
}
