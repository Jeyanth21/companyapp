import { Component, OnInit } from '@angular/core';
import { CompanyData } from 'src/app/models/companydata';
import { CompanyService } from '../company.service';
import{FormBuilder,FormControl,FormGroup,}from '@angular/forms';
import { CD } from 'src/app/models/cd';



@Component({
  selector: 'app-view-company',
  templateUrl: './view-company.component.html',
  styleUrls: ['./view-company.component.css']
})
export class ViewCompanyComponent implements OnInit {
  
  
  

formValue:FormGroup;
cd:CD= new CD()
showAdd:boolean;
showUpdate:boolean;
 

  constructor(private Company:CompanyService , private formbuilder:FormBuilder) { }

  // companydata:CompanyData[]=[];

  companydetail :CD[]=[];

    ngOnInit(): void {
      this.formValue= this.formbuilder.group({
        userID: [''],
        companyName: ['',[this.validateCompanyName.bind(this)]],
        turnover: [''],
        ceo: [''],
        stock_Exchange:[''],
        website:['']    
      })
       this.getAllCompany();
      // this.getcustomer();
    }
    validateCompanyName(control: FormControl) {
      let companyName = control.value;
      let existingCompany = this.companydetail.find(c => c.companyName == companyName);
      if(existingCompany) {
        return { companyNameExists: true }
      }
      return null;
    }


    getAllCompany(){
      this.Company.getcompany().subscribe(res=>{
        this.companydetail=res;
        
        
      })
    }
    
    // viewName(){
      // var c=JSON.parse(localStorage.getItem('UserName'));
      // this.cd.userName=c;
    // }
    

    // LogOut(){
      // localStorage.clear();
    // }

   clickAddCompany(){
     this.formValue.reset();
     this.showAdd=true;
     this.showUpdate=false;
   }
    
    postCompanyDetails(){
      var v=JSON.parse(localStorage.getItem('Id'));
      this.cd.userID=v;
     
     
      // this.cd.userID=this.formValue.value.userID;
      this.cd.companyName=this.formValue.value.companyName;
      this.cd.ceo=this.formValue.value.ceo;
      this.cd.turnover=this.formValue.value.turnover;
      this.cd.stock_Exchange=this.formValue.value.stock_Exchange;
      this.cd.website=this.formValue.value.website;

      this.Company.postCompany(this.cd).subscribe(res=>{
        console.log(res);
        alert("Company Added success")
        let ref=document.getElementById('cancel')
        ref?.click();
        this.formValue.reset();
        this.getAllCompany();
      },
      err=>{
        alert("something went wrong")
      }
      )
    }
    
      deleteCompanyDetails(item:any){
        this.Company.deleteCompany(item.userID).
        subscribe(res=>{
          alert("click  Ok to confirm ")
          });

        this.getAllCompany();

        
      }
      

      postComp(item:any){

        this.showAdd=false;
        this.showUpdate=true;
         this.cd.userID=item.userID;
          //  this.formValue.controls['userId'].setValue(item.userID);
        this.formValue.controls['companyName'].setValue(item.companyName);
        this.formValue.controls['ceo'].setValue(item.ceo);
        this.formValue.controls['turnover'].setValue(item.turnover);
        this.formValue.controls['stock_Exchange'].setValue(item.stock_Exchange);
        this.formValue.controls['website'].setValue(item.website);
      }
   

      // var n=JSON.parse(localStorage.getItem('name'));
      // this.cd.name=n;

      // UserName(){
        // var c=localStorage.getItem('Name');
        // this.cd.userName=c;

      // }


    updateCompanyd(){
      //  this.cd.userID=this.formValue.value.userID;
      var v=JSON.parse(localStorage.getItem('Id'));
      this.cd.userID=v;
       this.cd.companyName=this.formValue.value.companyName;
       this.cd.ceo=this.formValue.value.ceo;
       this.cd.turnover=this.formValue.value.turnover;
       this.cd.stock_Exchange=this.formValue.value.stock_Exchange;
       this.cd.website=this.formValue.value.website;
      this.Company.updateCompany(this.cd).subscribe(res=>{
        alert("updated Successfully");
        let ref=document.getElementById('cancel')
        ref?.click();
        this.formValue.reset();
        this.getAllCompany();

      })
    }
    LogOut(){
      localStorage.clear();
    }

}
