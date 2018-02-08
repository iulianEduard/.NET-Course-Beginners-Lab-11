import {Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProviderService } from '../../../services/provider.service/provider.service';
import {ToasterService} from 'angular2-toaster';

@Component({
  selector: 'synkwise-edit-provider',
  templateUrl: 'edit-provider.component.html',
  styleUrls: ['./edit-provider.component.css']
})
export class EditProviderComponent implements OnInit {
  providerData: any;

  constructor(private route: ActivatedRoute, private providerService: ProviderService, private  toasterService: ToasterService, private router: Router) {

  }

  ngOnInit() {
      // GET DATA FROM SERVER
    this.providerData =  this.providerService.getProvider().subscribe(result => {
           // this.providerService.getProviderById({providerId: 2}).subscribe(result => {
             if (result.status === 200) {
             /*   var userInfo = result as userModels.UserInfo;
        this.storageService.setLoggedUser(userInfo);
        this.auth.loggedUser$.next(true); */
                  this.router.navigateByUrl('/provider/home');
            }
           }, error => {
            if (JSON.parse(error.message)) {
                const errorObject = JSON.parse(error.message);
                this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
              }
        });
  }

  saveProviderData(entity: any) {
    // SEND DATA TO SERVER
    // this.ProviderService.saveProvider(entity);
    this.router.navigateByUrl('/provider/home');
        this.providerService.saveProvider(entity).subscribe(result => {
            this.providerData.address = 'primul pas';
           if (result.status === 200) {
            /*      var userInfo = result as userModels.UserInfo;
          this.storageService.setLoggedUser(userInfo);
          this.auth.loggedUser$.next(true); */
                  this.router.navigateByUrl('/provider/home');
              }
          }, error => {
           if (JSON.parse(error.message)) {
                const errorObject = JSON.parse(error.message);
                this.toasterService.pop('error', 'Error', errorObject.ResponseStatus.Message);
             }
         });

  }
}
