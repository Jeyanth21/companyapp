import { Injectable } from '@angular/core';
import{HttpClient,HttpParams,HttpHeaders}from '@angular/common/http';
import { CompanyData } from '../models/companydata';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  url='https://localhost:44329/api/Company_Details/getcompanydetails';
  posturl='https://localhost:44329/api/Company_Details/CreateCompanyDetails'


  constructor(private httpClient:HttpClient) { }

 

  getcompany() {
    let token = localStorage.getItem('Token');
     
    return this.httpClient.get<any>(this.url, {headers: {Authorization: `Bearer ${token}`}})
      .pipe(map((res: any) => {
        return res;
      },
      ))
  }
   postCompany(data:any)
   {
    let token = localStorage.getItem('Token');
     return this.httpClient.post<any>(this.posturl,data,{headers: {Authorization: `Bearer ${token}`}})
     .pipe(map((res:any)=>{
       return res;
     }))

   }

    // saveCompanyData(data:any){
      // console.log(data)
      // return this.httpClient.post(this.posturl,data);



    // }

    deleteCompany(userID:number){
      let token = localStorage.getItem('Token');
      return this.httpClient.delete<any>("https://localhost:44329/api/Company_Details/DeleteCompanyDetails/"+userID,{headers: {Authorization: `Bearer ${token}`}})
      .pipe(map((res:any)=>{
        return res;
      }))
    }

    updateCompany(data:any){
      let token = localStorage.getItem('Token');
      return this.httpClient.put<any>("https://localhost:44329/api/Company_Details/UpdateCompanyDetails",data,{headers: {Authorization: `Bearer ${token}`}})
      .pipe(map((res:any)=>{
       return res;
     }))
    }
  
}
