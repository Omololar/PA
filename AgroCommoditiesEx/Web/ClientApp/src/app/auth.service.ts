import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,  HttpParams } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { map, catchError, tap } from 'rxjs/operators';
import { User } from './user';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseurl = 'https://localhost:5001/api/account';
  userToken: any;

  constructor(private httpClient: HttpClient) { }
 
  createUser(user) {
    return this.httpClient.post(`${this.baseurl}/register/`, user);
  }


  login(model) {
    return this.httpClient.post(`${this.baseurl}/login/`, model)
      .pipe(
        map(user => {
           
           // const user = response.json();
        if (user) {
          localStorage.setItem('token', JSON.stringify(user));
          this.userToken = JSON.stringify(user);
          console.log(this.userToken);
            }
      })
       );
  }

  logout() {
    // remove user from local storage to log user out
    
    localStorage.removeItem('token');
  }
  public get loggedIn(): boolean {
    return localStorage.getItem('token') !== null;
  }
 
}

