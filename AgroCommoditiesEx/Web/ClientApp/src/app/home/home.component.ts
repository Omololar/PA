import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../product.service';
//import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  users: Object;//Observable<Product[]>;
  //products: Product;
  error: {};
 
  constructor(private data: ProductService) { }

  ngOnInit() {
    this.data.getProducts().subscribe(data => {
      this.users = data
      console.log(this.users);
    });
    //this.productService.getProducts().subscribe(
    //  (data: Product) => 
    //  this.products = data,
    //    //console.log(this.farmproduct);
    //    error => this.error =error
     
    //);
  }
  //getProduct() {
  //  return this.productService.getProducts();
  //  //this.productService.getProducts().subscribe(response => {
  //  //  this.products = response as Observable<Product[]>;
  //  //  console.log(this.products);
  //  //});
  //}

}
