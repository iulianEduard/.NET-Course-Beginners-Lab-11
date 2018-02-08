import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions, URLSearchParams} from '@angular/http';
import {Observable} from 'rxjs/Observable';

// import { StorageService } from '../storage.service';
import {environment} from '../../../../environments/environment';
import {HttpParams} from "@angular/common/http";

@Injectable()
export class ApiService {

  constructor(private http: Http,
              //private storageService: StorageService
  ) {
  }

  getWithParam(url: string, urlParam: any): Observable<any> {
    let options = this.generateRequestOptions();

    let params: URLSearchParams = new URLSearchParams();
    Object.keys(urlParam)
      .forEach((key) => {
        params.set(key, urlParam[key]);
      });
    options.search = params;

    return this.http.get(environment.backend + url, options)
      .map((res) => res.json())
      .catch((err) => Observable.throw(new Error(err._body)));
  }

  get(url: string): Observable<any> {
    // if (!this.isTokenExpired()) {
    let options = this.generateRequestOptions();

    return this.http.get(environment.backend + url, options)
      .map((res) => res.json())
      .catch((err) => Observable.throw(new Error(err._body)));
    // }
    // else {
    //   return Observable.throw(new Error('Your login session has expired'));
    // }
  }

  post(url: string, data: any): Observable<any> {
    //if (!this.isTokenExpired()) {
    let bodyString = data; //JSON.stringify(data);
    let options = this.generateRequestOptions();

    return this.http.post(environment.backend + url, bodyString, options)
      .map((res) => res.json())
      .catch((err) => Observable.throw(new Error(err._body)));
    //}
    // else {
    //   return Observable.throw(new Error('Your login session has expired'));
    // }
  }

  put(url: string, data: any): Observable<any> {
    //if (!this.isTokenExpired()) {
    let bodyString = JSON.stringify(data);
    let options = this.generateRequestOptions();

    return this.http.put(environment.backend + url, bodyString, options)
      .map((res) => res.json())
      .catch((err) => Observable.throw(new Error(err._body)));
    //}
    // else {
    //   return Observable.throw(new Error('Your login session has expired'));
    // }
  }

  private generateRequestOptions(): RequestOptions {
    return new RequestOptions({
      headers: this.generateRequestHeader()
    });
  }

  private generateRequestHeader(): Headers {
    var headers = new Headers({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
      'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token'
    });

    // if (this.storageService.getLoggedUser()) {
    //   headers.set('Authorization', 'Bearer ' + this.storageService.getLoggedUser().token);
    // }

    return headers;
  }

  // private isTokenExpired() {
  //   var user = this.storageService.getLoggedUser();
  //   if (user) {
  //     const tokenCreateDate = moment(user.createdAt);
  //     const now = moment();
  //
  //     const diff = now.diff(tokenCreateDate, 'seconds');
  //
  //     // if token is expired
  //     if (diff > user.expires_in) {
  //       // logout user -> remove token
  //       this.store.dispatch(new userActions.LogoutAction());
  //
  //       return true;
  //     }
  //     else {
  //       return false;
  //     }
  //   }
  //
  //   return false;
  // }
}
