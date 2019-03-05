import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../auth.service';
import { first, tap, catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { User } from '../user';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

 
  baseurl = 'https://localhost:5001/api/account/';


  public UserType: any[];

  registerForm: FormGroup;
  loading = false;
  submitted = false;


  constructor(private http: HttpClient, private formBuilder: FormBuilder, private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
    this.getValues();

    this.registerForm = this.formBuilder.group({
      FirstName: new FormControl('', [Validators.required]),
      LastName: new FormControl('', [Validators.required]),
      Email: new FormControl('', [Validators.required]),
      Password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      ConfirmPassword: new FormControl('', [Validators.required, Validators.minLength(6)]),
      UserType: new FormControl('', [Validators.required]),
      PhoneNumber: new FormControl('', [Validators.required])
    });
  }


  get f() { return this.registerForm.controls; }

  createUser() {
    var user = this.registerForm.value;
    this.authService.createUser(user).subscribe(result  => {if(result){
      this.router.navigate(['/login'], { queryParams: { brandNew: true, email: user.Email}});                         
          }},
     
      error => {
        console.log(error);
        this.loading = false;
    });
  };


  getValues() {
    this.http.get('https://localhost:5001/api/account/register').subscribe(response => {
      this.UserType = response as any[];
      console.log(this.UserType);
    });
  }

}
