import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminService } from 'src/app/Services/admin.service';
import { SubCategory } from 'src/app/Model/sub-category';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-sub-categories',
  templateUrl: './view-sub-categories.component.html',
  styleUrls: ['./view-sub-categories.component.css']
})
export class ViewSubCategoriesComponent implements OnInit {
  viewsubcatForm:FormGroup;
  submitted=false;
viewsubcategory:SubCategory;
viewsubcategoryList:SubCategory[];

  constructor(private fromBuilder:FormBuilder,private route:Router,private service:AdminService) { 
    
    }
    
  View()
  {
    this.service.ViewSubCategories().subscribe(res=>
      {
        this.viewsubcategoryList=res;
        console.log(this.viewsubcategoryList)
      },
      err=>{
        console.log(err);
      })
  }



  ngOnInit(){
    this.viewsubcatForm=this.fromBuilder.group({
       
       categoryId:[''],
       subcategoryId:[''],
       subcategoryName:[''],
       briefDetails:[''],
       gst:['',Validators.required]
       
 
   });
   this.View();
 }

 GetSubCatById(subcatid:string)
 {

   this.service.GetSubCatById(subcatid).subscribe 
      (
        res=>
        {
          this.viewsubcategory=res;
          console.log("get");
          console.log(this.viewsubcategory);
          console.log('Id Found');
          this.viewsubcatForm.setValue(
            {
              categoryId:this.viewsubcategory.categoryId, 
              subcategoryId:this.viewsubcategory.subcategoryId,
              subcategoryName:this.viewsubcategory.subcategoryName,
              gst:this.viewsubcategory.gst,
              briefDetails:this.viewsubcategory.briefDetails,
              
            }
          )
        },
        err=>
        {
          console.log(err);
        }
      )
      // this.Edit(this.category);
    }
 
    Edit()
    {
      let catobj=new SubCategory();  
      console.log(catobj);
      catobj.categoryId=this.viewsubcatForm.value['categoryId'];
      catobj.subcategoryId=this.viewsubcatForm.value['subcategoryId'];
      catobj.subcategoryName=this.viewsubcatForm.value['subcategoryName'];
      catobj.gst=this.viewsubcatForm.value['gst'];
      catobj.briefDetails=this.viewsubcatForm.value['briefDetails'];
      this.service.EditSubCategories(catobj).subscribe(res=>{
          this.viewsubcategory=res;
          console.log(this.viewsubcategory);
          alert("Record Updated");
        this.route.navigateByUrl('/admin/view-sub-categories');
        
    })
    this.View();
      }

 Delete(subcatid:string)
    {
      this.service.DeleteSubCategories(subcatid).subscribe
  (
    res=>
    {
      console.log('Record Deleted');
      alert("Do u want to delete");
      alert("Record Deleted");
      this.route.navigateByUrl('/admin/view-sub-categories');
    },
    err=>
    {
      console.log(err);
    }
  )
  this.View();
}
}