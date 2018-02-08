/**
 * Created by coprita on 1/13/2018.
 */
import {Component, OnInit, Input, SimpleChanges, OnChanges} from '@angular/core';

@Component({
  selector: 'synkwise-resident-careplan-enhance',
  templateUrl: 'enhance.component.html',
  styleUrls: ['enhance.component.css']
})
export class CareplanEnhanceComponent implements OnInit, OnChanges {
  @Input() initialDetails: any;
  private itemEnhanceDetails: any;

  ngOnInit() {
    this.itemEnhanceDetails = [
      {
        label: "Clubs/organization",
        input1: "residentPref",
        input2: "caregiverResp",
        id1: "enhanceIssue1ID",
        id2: "enhanceIssue2ID"
      },
      {label: "Spiritual", id1: "enhanceSpiritual1ID", id2: "enhanceSpiritual2ID"},
      {label: "Cultural", id1: "enhanceCultural1ID", id2: "enhanceCultural2ID"},

      {label: "Family/friends", id1: "caregiverFamilyID1", id2: "caregiverFamilyID2"},
      {label: "Hobbies", id1: "enhanceHobbies1", id2: "enhanceHobbies2"},
      {label: "Special arrangements", id1: "enhanceSpecialID1", id2: "enhanceSpecialID2"},
      {label: "Favorite pastime activities", id1: "enhancepastimeID1", id2: "enhancepastimeID2"},
      {label: "Most important daily activities for resident", id1: "enhanceactivitiesID1", id2: "enhanceactivitiesID2"}];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialDetails'] && this.initialDetails) {
      this.itemEnhanceDetails = this.initialDetails;
    }
  }
}
