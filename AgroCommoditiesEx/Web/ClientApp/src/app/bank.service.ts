import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BankService {
  baseurl = 'https://localhost:5001/api/bank';

  constructor(private httpClient: HttpClient) { }

  getbanks() {
    return this.httpClient.get(`${this.baseurl}/getbanks/`);
  }


  addbankdetails(model) {
    return this.httpClient.post(`${this.baseurl}/addbankdetails/`, model);
  }



}
