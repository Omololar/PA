import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { AuthService } from '../auth.service';
import { BankService } from '../bank.service';
import { ProductService } from '../product.service';
import { NbDialogService, NbPopoverDirective } from '@nebular/theme';
import { Observable } from 'rxjs';
import { Product } from '../product';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent implements OnInit {


  productMode = false;
  users: Object;
  loading = false;
  submitted = false;
  bankForm: FormGroup;
  public BankName: any[];
  public show_dialog: boolean = false;
  @ViewChild(NbPopoverDirective) popover: NbPopoverDirective;


  constructor(private formBuilder: FormBuilder, private authService: AuthService, private bankService: BankService,
    private router: Router, private productService: ProductService, private dialogService: NbDialogService) { }
  ngOnInit() {

    this.getbanks();
    this.getProducts();
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

 
  
  


  getProducts() {
    this.productService.getProducts().subscribe(data => {
      this.users = data 
      console.log(this.users);
    });
  }
  productToggle() {
    this.productMode = true;
  }

 
}
