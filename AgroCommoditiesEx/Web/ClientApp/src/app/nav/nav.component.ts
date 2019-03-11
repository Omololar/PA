import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.sass']
})
export class NavComponent implements OnInit {
 
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
  logout() {
    this.authService.userToken = null;
    localStorage.removeItem('token');
    console.log('logged out');
  }

 
}

