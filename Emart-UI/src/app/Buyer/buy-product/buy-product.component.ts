import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Items } from 'src/app/Model/items';
import { BuyerService } from 'src/app/Services/buyer.service';
import { TransactionHistory } from 'src/app/Model/transaction-history';

@Component({
  selector: 'app-buy-product',
  templateUrl: './buy-product.component.html',
  styleUrls: ['./buy-product.component.css']
})
export class BuyProductComponent implements OnInit {

  transForm:FormGroup;
  transactionhistory:TransactionHistory;
  itemlist:Items[];
  item:Items
 numberofitems:number=1;
  constructor(private formbuilder:FormBuilder,private service:BuyerService) { }

  ngOnInit() {

    this.item=JSON.parse(localStorage.getItem('item'));
  console.log(this.item);
  console.log(this.item.itemId);
  this.transForm=this.formbuilder.group({
    transactiontype:['',[Validators.required]],
    name:['',[Validators.required]],
    cardNumber:['',[Validators.required]],
    cvv:['',[Validators.required]],
    edate:['',[Validators.required]],
    numberofitems:['',[Validators.required]]
  

  
  });
  

  }


  get f()
{
  return this.transForm.controls;
}
  onSubmit()
{
  this.transactionhistory=new TransactionHistory();
  this.transactionhistory.id='I'+Math.round(Math.random()*999);
  this.transactionhistory.transactionid='T'+Math.round(Math.random()*999);
  this.transactionhistory.buyerid=localStorage.getItem('buyerid');
  this.transactionhistory.sellerid=this.item.sellerId;
  this.transactionhistory.numberofitems=this.transForm.value["numberofitems"];
  this.transactionhistory.itemid=this.item.itemId;
  this.transactionhistory.transactiontype=this.transForm.value["transactiontype"]
  this.transactionhistory.datetime=new Date();
  this.transactionhistory.remarks=this.item.remarks;
     console.log(this.transactionhistory);
     this.service.BuyItem(this.transactionhistory).subscribe(
       res=>{
       console.log("Transaction is Successfull");
       alert('Ordered Successfully');
     })
    }
     incrementQty()
     {
      this.numberofitems+= 1;
      console.log(this.numberofitems + 1);
      }
      
      //decrements item
      
      decrementQty(){
      if(this.numberofitems-1 < 1){
        this.numberofitems = 1;
        console.log('' + this.numberofitems)
      }
      else{
        this.numberofitems-= 1;
        console.log('' + this.numberofitems);
      }
      }

}

   







