import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { AuthService } from '../auth.service';
import { BankService } from '../bank.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  productMode = false;

  loading = false;
  submitted = false;
  bankForm: FormGroup;
  public BankName: any[];
  public show_dialog: boolean = false;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private bankService: BankService,
    private router: Router) { }
  ngOnInit() {

    this.getbanks();
    this.bankForm = this.formBuilder.group({
      ContactAddress: new FormControl('', [Validators.required]),
      BankAccountNo: new FormControl('', [Validators.required]),
      AccountName: new FormControl('', [Validators.required]),
      BankName: new FormControl('', [Validators.required]),

    });
  }
  onSubmit() {
    var model = this.bankForm.value;
    this.bankService.addbankdetails(model).subscribe(k => {
      if (k) {
        console.log(model);
        this.router.navigate(['/product']);
      }
    },

      error => {
        console.log(error);
        this.loading = false;
      });
  };

  getbanks() {
    this.bankService.getbanks().subscribe(response => {
      this.BankName = response as any[];
      console.log(this.BankName);
    });
  }

  productToggle() {
    this.productMode = !this.productMode;
  }
}
