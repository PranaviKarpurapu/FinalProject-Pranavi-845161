import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Items } from '../Model/items';
import { TransactionHistory } from '../Model/transaction-history';
import { Cart } from '../Model/cart';
import { Buyer } from '../Model/buyer';

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

  public ViewCart(buyerid:string) :Observable<Cart>
  {
    return this.http.get<Cart>(this.url+'ViewCart/'+buyerid,Requestheaders);
   }

   public Addtocart(cartobj:Cart) :Observable<Cart>
  {
    return this.http.post<Cart>(this.url+'Addtocart',cartobj,Requestheaders);
   }

   public Deletefromcart(cartid:string) :Observable<Cart>
  {
    return this.http.delete<Cart>(this.url+'Deletefromcart/'+cartid,Requestheaders);
   }

   public TransactionHistory(buyerid:string) :Observable<TransactionHistory>
  {
    return this.http.get<TransactionHistory>(this.url+'TransactionHistory/'+buyerid,Requestheaders);
   }

   public EditProfile(buyer:Buyer) : Observable<any>
   {
     return this.http.put<any>(this.url+'EditProfile',JSON.stringify(buyer),Requestheaders)
   }

   public ViewProfile(id:string) : Observable<Buyer>
   {
     return this.http.get<Buyer>(this.url+'ViewProfile/'+id,Requestheaders)
   }

}



