import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.sass']
})
export class BuyComponent implements OnInit {
  buyForm: FormGroup;
  users: Object;

 
  public BankName: any[];

  constructor(private formBuilder: FormBuilder, private productService: ProductService) { }

  ngOnInit() {
    this.getProducts();
    this.buyForm = this.formBuilder.group({
      option: new FormControl('', [Validators.required]),
      productName: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      Quantity: new FormControl('', [Validators.required]),
    });        
  }
  getProducts() {
    this.productService.getProducts().subscribe(data => {
      this.users = data
      console.log(this.users);
    });
  }


}
