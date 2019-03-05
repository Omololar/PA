import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../product.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  
  

  productForm: FormGroup;

  @ViewChild('defaultupload')
  public uploadInput: string = '';

  url = '';
  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed
       // this.url = event.target.result;
      }
    }
  }

  loading = false;
  submitted = false;
  products: Object;
  constructor(private productService: ProductService, private formBuilder: FormBuilder,
    private router: Router) { }



  ngOnInit() {
    this.productForm = this.formBuilder.group({
      Quantity: new FormControl('', [Validators.required]),
      ProductName: new FormControl('', [Validators.required]),
      PhotoUrl: new FormControl('', [Validators.required]),
      Price: new FormControl('', [Validators.required, Validators.minLength(6)]),
     });
  }

  
  
  
  get f() { return this.productForm.controls; }

  addProduct() {
    var user = this.productForm.value;
    this.productService.addproduct(user).subscribe(result => {
      console.log(user);
      //if (result) {
      //  this.router.navigate(['/login'], { queryParams: { brandNew: true, email: user.Email } });
      //}
    },

      error => {
        console.log(error);
        this.loading = false;
      });
  };
}
