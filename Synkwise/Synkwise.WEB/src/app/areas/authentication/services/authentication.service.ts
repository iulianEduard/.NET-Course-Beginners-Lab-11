/**
 * Created by coprita on 11/19/2017.
 */
import {Injectable} from '@angular/core';
import {LoginModel} from '../../../shared/models/login/loginModel';
import 'rxjs/add/operator/toPromise';
import {ApiService} from '../../../shared/services/api.service';
import {BehaviorSubject} from "rxjs";

@Injectable()
export class AuthService {
  loggedUser$ = new BehaviorSubject<boolean>(false);

  constructor(private apiService: ApiService) {
  }

  login(user: LoginModel) {
    let urlLogin: string = "/api/account/login";
    return this.apiService.post(urlLogin, user);
  }

  register(user: any) {
    let urlRegister: string = '/api/account/register';
    return this.apiService.post(urlRegister, user);
  }

  confirmRegistration(confirmation: any) {
    let urlRegister: string = '/api/account/confirm';
    return this.apiService.post(urlRegister, confirmation);
  }

  validateRegisterCode(registerCode: string){
    let urlProviders = '/api/account/validate/' + registerCode;
    return this.apiService.get(urlProviders);
  }

  forgotPasword(email: any) {
    let urlForgot: string = '/api/account/forgot';
    return this.apiService.post(urlForgot, email);
  }

  resetPasword(email: any) {
    let urlResetPassword: string = '/api/account/resetpassword';
    return this.apiService.post(urlResetPassword, email);
  }

  //ensureAuthenticated(token): Promise<any> {
  //    let url: string = `${this.BASE_URL}/status`;
  //    let headers: Headers = new Headers({
  //        'Content-Type': 'application/json',
  //        Authorization: `Bearer ${token}`
  //    });
  //    return this.http.get(url, { headers: headers }).toPromise();
  //}
}
