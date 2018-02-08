import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';

import {ApiService} from '../../../../shared/services/api.service';
import {RoleModel} from "../../../../shared/models/common/roleModel";

@Injectable()
export class ManagementService {

  constructor(private apiService: ApiService) {
  }

  sendInvitation(invitation: any) {
    return this.apiService.post('/api/invitation', invitation);
  }

  updateInvitation(invitation: any, id: number) {
    return this.apiService.put('/api/invitation/'+id, invitation);
  }

  getAllInvitation(gridParam: any) {
    return this.apiService.getWithParam('/api/invitations', gridParam);
  }

  get(id: number) {
    return this.apiService.get('/api/invitations/' + id);
  }

  getProviderInvitation(providerId: number) {
    return this.apiService.get('/api/providers/' + providerId + '/invitations');
  }

  getRoles() {
    return this.apiService.get('/api/roles');
  }
}
