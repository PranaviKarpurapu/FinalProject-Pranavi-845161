import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Items } from '../Model/items';
import { TransactionHistory } from '../Model/transaction-history';

const Requestheaders={headers:new HttpHeaders(
  {'content-Type':'application/json',
  'Authorization': 'Bearer '+localStorage.getItem('token')
}
)
}

@Injectable({
  providedIn: 'root'
})
export class BuyerService {

  url:string='http://localhost:55179/Buyer/'
  constructor(private http:HttpClient) { }

  public SearchItems(name:string) : Observable<Items[]>
  {
    return this.http.get<Items[]>(this.url+'SearchItems/'+name,Requestheaders)
  }


  public BuyItem(item:TransactionHistory) : Observable<TransactionHistory>
  {
    console.log(item)
    return this.http.post<TransactionHistory>(this.url+'BuyItem/',item,Requestheaders)
  }
}
