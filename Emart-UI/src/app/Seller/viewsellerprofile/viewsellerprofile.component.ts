import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Seller } from 'src/app/Model/seller';
import { SellerService } from 'src/app/Services/seller.service';


@Component({
  selector: 'app-viewsellerprofile',
  templateUrl: './viewsellerprofile.component.html',
  styleUrls: ['./viewsellerprofile.component.css']
})
export class ViewsellerprofileComponent implements OnInit {

  itemForm:FormGroup;
  submitted=false;
seller:Seller;
 sellerlist:Seller[];
  constructor(private fromBuilder:FormBuilder,private service: SellerService) {
    let sid= localStorage.getItem('sellerid')
 this.service.ViewProfile(sid).subscribe(res=>
  {
    this.seller=res;
    console.log("get");
    console.log(this.seller);
    console.log('Id Found');
    //console.log(res);
    this.itemForm.patchValue(
      {
       
      sellerId:localStorage.getItem('sellerid'),
      userName:this.seller.userName,
        password:this.seller.password,
      companyName:this.seller.companyName,
        gstin:this.seller.gstin,
        briefDetails:this.seller.briefDetails,
        postalAddress:this.seller.postalAddress,
        website:this.seller.website,
        emailId:this.seller.emailId,
        mobileNo:this.seller.mobileNo
        
      }
    )
  },
  err=>
  {
    console.log(err);
  }
)

   

   }

  ngOnInit() {
   
    this.itemForm=this.fromBuilder.group({
        sellerId:[''],
        userName:[''],
      password:[''],
      briefDetails:[''],
      companyName:[''],
      gstin:[''],
      postalAddress:[''],
      emailId:[''],
      mobileNo:[''],
      website:['']

    });
  }

  onSubmit()
  {
    this.submitted=true;
   
}
get f()
{
  return this.itemForm.controls;
}
onReset()
{
this.submitted=false;
this.itemForm.reset();
}
}


