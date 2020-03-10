import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Items } from 'src/app/Model/items';
import { BuyerService } from 'src/app/Services/buyer.service';
import { TransactionHistory } from 'src/app/Model/transaction-history';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buy-product',
  templateUrl: './buy-product.component.html',
  styleUrls: ['./buy-product.component.css']
})
export class BuyProductComponent implements OnInit {
  buyerform:FormGroup;
  item:Items;
  pobj:TransactionHistory;
    constructor(private formbuilder:FormBuilder,private service:BuyerService,private route:Router) { }
  
    ngOnInit() {
  this.buyerform=this.formbuilder.group({
    transactionType:[''],
    cardNumber:[''],
    cvv:[''],
    edate:[''],
    name:[''],
    dateTime:[''],
    numberOfItems:[''],
    remarks:['']
  })
  this.item=JSON.parse(localStorage.getItem('item'));
  console.log(this.item);
  console.log(this.item.itemId);
    }
  onSubmit()
  {
    this.pobj=new TransactionHistory();
    this.pobj.transactionId='T'+Math.round(Math.random()*999);
    this.pobj.buyerId=localStorage.getItem('buyerId');
    this.pobj.sellerId=this.item.sellerId;
    this.pobj.numberOfItems=this.buyerform.value["numberOfItems"];
    this.pobj.itemId=this.item.itemId;
    this.pobj.itemname=this.pobj.itemname;
    this.pobj.image=this.item.image;
    this.pobj.transactionType=this.buyerform.value["transactionType"]
       this.pobj.dateTime=this.buyerform.value["dateTime"];
       this.pobj.remarks=this.buyerform.value["remarks"];

       console.log(this.pobj);
       this.service.BuyItem(this.pobj).subscribe(res=>{
         console.log("Purchase was Sucessfull");
         alert('Purchase Done Successfully');
       })
  
  }
    
  
  }
  


//   numberofitems:number=1;

//   transForm:FormGroup;
//   transactionhistory:TransactionHistory;
//   itemlist:Items[];
//   item:Items
//   submitted: boolean;
 
//   constructor(private formbuilder:FormBuilder,private service:BuyerService) { }

//   ngOnInit() {

//     this.item=JSON.parse(localStorage.getItem('item'));
//   console.log(this.item);
//   console.log(this.item.itemId);
//   this.transForm=this.formbuilder.group({
     
//     transactiontype:['',[Validators.required]],
//     cardNumber:['',[Validators.required]],
//     cvv:['',[Validators.required]],
//     edate:[''],
//     name:['',[Validators.required]], 
//     numberofitems:['',Validators.required],
    

  
//   });
  

//   }

//   get f()
//   {
//     return this.transForm.controls;

//   }

//   onSubmit()
// {
//   this.item=JSON.parse(localStorage.getItem('item'));
//   console.log(this.item);
//     console.log(this.item.itemId);  
//     console.log(this.transactionhistory);    

//   console.log(JSON.stringify(this.transForm.value));

//   this.submitted=true;
//   //display from values on success
//   if(this.transForm.valid)
//   {
//     alert('sucess!!!!!!')
 
    
 
//   this.transactionhistory=new TransactionHistory();
//   this.transactionhistory.id='I'+Math.round(Math.random()*999);
//   this.transactionhistory.transactionid='T'+Math.round(Math.random()*999);
//   this.transactionhistory.buyerid=localStorage.getItem('buyerid');
//   this.transactionhistory.sellerid=this.item.sellerId;
//   this.transactionhistory.numberofitems=this.transForm.value["numberofitems"];
//   this.transactionhistory.itemid=this.item.itemId;
//   this.transactionhistory.transactiontype=this.transForm.value["transactiontype"]
//   this.transactionhistory.datetime=new Date();
//   this.transactionhistory.remarks=this.item.remarks;


//      console.log(this.transactionhistory);
//      this.service.BuyItem(this.transactionhistory).subscribe(
//        res=>{
//        console.log("Transaction is Successfull");
//        alert('Ordered Successfully');
//      })
//     }
//     }

// incrementQty()
// {
//  this.numberofitems+= 1;
//  console.log(this.numberofitems + 1);
//  }
 
//  //decrements item
 
//  decrementQty(){
//  if(this.numberofitems-1 < 1){
//    this.numberofitems = 1;
//    console.log('' + this.numberofitems)
//  }
//  else{
//    this.numberofitems-= 1;
//    console.log('' + this.numberofitems);
//  }
//  }


// }