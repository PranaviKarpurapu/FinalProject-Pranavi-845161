import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Category } from 'src/app/Model/category';
import { AdminService } from 'src/app/Services/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  categoryForm:FormGroup;
  submitted=false;
  category:Category;
  categorylist:Category[];
  constructor(private route:Router,private fromBuilder:FormBuilder,private service: AdminService) { }



  
  ngOnInit() {
    this.categoryForm=this.fromBuilder.group({
     
      
      CategoryName:['',[Validators.required,Validators.pattern('^[a-zA-Z]{3,15}$')]],
      BriefDetails:['',[Validators.minLength(5)]],

    
    });
  }


  get f()
  {
    return this.categoryForm.controls;

  }
  
  onSubmit()
  {
    this.submitted=true;
    //display from values on sucess
    if(this.categoryForm.valid)
    {
      alert('sucess!!!!!!')
      console.log(JSON.stringify(this.categoryForm.value));
    }
    this.Add();
  }
    onReset()
    {

    this.submitted=false;
    this.categoryForm.reset();
    }

    Add()
    {

      this.category=new Category();
      this.category.categoryId='C'+Math.floor(Math.random()*10000);
      this.category.categoryName=this.categoryForm.value["CategoryName"];
      this.category.briefDetails=this.categoryForm.value["BriefDetails"];
      this.service.AddCategories(this.category).subscribe 
      (
        res=>
        {
          console.log('Record Added');
           this.route.navigateByUrl('/admin/view-categories');
        },
        err=>
        {
          console.log(err);
        }
      )
    }
  
  }

  

