import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map, catchError, tap } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  baseurl = 'https://localhost:5001/api/account';
  userToken: any;

  constructor(private httpClient: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
}

  createUser(user) {
    return this.httpClient.post(`${this.baseurl}/register/`, user);
  }


  login(model) {
    return this.httpClient.post(`${this.baseurl}/login/`, model)
      .pipe(
        map(user => {

         
          if (user) {
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUserSubject.next(user);

            //this.userToken = JSON.stringify(user);
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
