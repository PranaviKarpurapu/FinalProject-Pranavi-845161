import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators } from '@angular/forms';
import { Seller } from 'src/app/Model/seller';
import { AccountService } from 'src/app/Services/account.service';
@Component({
  selector: 'app-registerseller',
  templateUrl: './registerseller.component.html',
  styleUrls: ['./registerseller.component.css']
})
export class RegistersellerComponent implements OnInit {

  registerForm:FormGroup;
  submitted=false;
  seller:Seller;
  sellerlist:Seller[];


  constructor(private fromBuilder:FormBuilder,private service: AccountService) { }


  ngOnInit() {
    this.registerForm=this.fromBuilder.group({
      // title:['',Validators.required],
      SellerId:['',[Validators.required]],
      UserName:['',[Validators.required,Validators.pattern('^[a-zA-Z]{6,15}$')]],
      MobileNo:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
      EmailId:['',[Validators.required,Validators.email]],
      Password:['',[Validators.required,Validators.minLength(6)]],
      PostalAddress:['',Validators.required],
      GSTIN :['',Validators.required],
      Website:['',[Validators.required,Validators.maxLength(25)]],
      CompanyName:['',[Validators.required,Validators.maxLength(30)]],
      BriefDetails:[''],
      // acceptTerms:[false,Validators.requiredTrue]
    
    });
  }


  get f()
  {
    return this.registerForm.controls;

  }
  
  onSubmit()
  {
    this.submitted=true;
    //display from values on sucess
    if(this.registerForm.valid)
    {
      alert('sucess!!!!!!')
      console.log(JSON.stringify(this.registerForm.value));
      this.Register();
    }
  }
    onReset()
    {

    this.submitted=false;
    this.registerForm.reset();
    }

    Register()
    {

      this.seller=new Seller();
      this.seller.sellerId='S'+Math.floor(Math.random()*1000);
      this.seller.userName=this.registerForm.value["UserName"];
      this.seller.mobileNo=(this.registerForm.value["MobileNo"]);
      this.seller.emailId=this.registerForm.value["EmailId"];
      this.seller.gstin=this.registerForm.value["GSTIN"];
      this.seller.password=this.registerForm.value["Password"];
      this.seller.postalAddress=this.registerForm.value["PostalAddress"];
      this.seller.website=this.registerForm.value["Website"];
      this.seller.companyName=this.registerForm.value["CompanyName"];
      this.seller.briefDetails=this.registerForm.value["BriefDetails"];
      this.service.RegisterSeller(this.seller).subscribe
      (
        res=>
        {
          console.log('Record Added');
          alert("Details Registered");
        },
        err=>
        {
          console.log(err);
        }
      )
    }
  
  }

