import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
//import { Product } from './models/product';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseurl = 'https://localhost:5001/api/product';

  constructor(private httpClient: HttpClient) { }

  getProducts() {
    return this.httpClient.get('https://localhost:5001/api/product/getProducts')
  }


  //getProducts(): Observable<Product[]> {
  //  return this.httpClient.get<Product[]>(`${this.baseurl}/getProducts/`);
  //}


  addproduct(model) {
    return this.httpClient.post(`${this.baseurl}/addproduct/`, model);
  }
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {

      // A client-side or network error occurred. Handle it accordingly.

      console.error('An error occurred:', error.error.message);
    } else {

      // The backend returned an unsuccessful response code.

      // The response body may contain clues as to what went wrong.

      console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
    }

    // return an observable with a user-facing error message

    return throwError('Something bad happened. Please try again later.');
  }
}
