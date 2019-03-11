import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  loginMode = false;

  registerMode = false;
  users: Object;
  error: {};



  constructor(private data: ProductService) { }

  ngOnInit() {
    this.data.getProducts().subscribe(data => {
      this.users = data
      console.log(this.users);
    });
   
  }
  loginToggle() {
    this.loginMode = true;
    this.registerMode = false;
  }
  cancelLoginMode(loginMode: boolean) {
    this.loginMode = loginMode;
  }
  
  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

  registerToggle() {
    this.registerMode = true;
    this.loginMode = false;
  }

  
}
