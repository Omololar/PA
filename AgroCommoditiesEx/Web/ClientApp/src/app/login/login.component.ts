import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from 'selenium-webdriver/http';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { BankService } from '../bank.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;


  bankForm: FormGroup;
  public BankName: any[];
  public show_dialog: boolean = false;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private bankService: BankService,
    private router: Router) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      Email: new FormControl('', [Validators.required]),
      Password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
    this.authService.logout();
    //this.returnUrl = this.router.navigate.queryParams['returnUrl'] || '/';

    //this.getbanks();
    //this.bankForm = this.formBuilder.group({
    //  ContactAddress: new FormControl('', [Validators.required]),
    //  BankAccountNo: new FormControl('', [Validators.required]),
    //  AccountName: new FormControl('', [Validators.required]),
    //  BankName: new FormControl('', [Validators.required]),

    //});

  }

  get f() { return this.loginForm.controls; }
  loginUser() {
    this.show_dialog = !this.show_dialog;
    var user = this.loginForm.value;
    this.authService.login(user).subscribe(result => {
     this.router.navigate(['/dashboard']);
      //this.router.navigate(['/']);
        
        //this.router.navigate(['/'], { queryParams: { brandNew: true, email: user.Email } });
     
    },

      error => {
        console.log(error);
        this.loading = false;
      });
  };

  //logout() {
  //  this.authService.userToken = null;
  //  localStorage.removeItem('token');
  //}

  //onSubmit() {
  //  var model = this.bankForm.value;
  //  this.bankService.addbankdetails(model).subscribe(k => {
  //    if (k) {
  //      console.log(model);
  //      this.router.navigate(['/product']);
  //    }
  //  },

  //    error => {
  //      console.log(error);
  //      this.loading = false;
  //    });
  //};

  //getbanks() {
  //  this.bankService.getbanks().subscribe(response => {
  //    this.BankName = response as any[];
  //    console.log(this.BankName);
  //  });
  //}



  //loggedIn() {
  //  const token = localStorage.getItem('token');
  //  return !!token;
  //}
}


