import { ComponentFixture, ComponentFixtureNoNgZone, TestBed } from '@angular/core/testing';
import{FormBuilder,}from '@angular/forms';
import {  FormGroup, FormsModule ,ReactiveFormsModule} from "@angular/forms";
import { LoginComponent } from './login.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import {  HttpClient, HttpClientModule } from '@angular/common/http';
import { LoginModel } from 'src/app/models/loginmodel';
import { of } from 'rxjs';


describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let mockHttpService: jasmine.SpyObj<HttpClient>;
  let loginres;

  

  beforeEach(async () => {



   
   

    mockHttpService = jasmine.createSpyObj('HttpClient', [
      
      'post',
      
      
    ]);
  
   loginres= [{
        "id": 8,
        "userName": "nayeon",
        "email": "jyp@gmail.com",
        "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJleHAiOjE2NzExNjU5NTIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjE2MDUiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYxNjA1In0.S1k-AhanCFzpH-RvSfB8mhWl-DfJDEYGUyAtqYuhvHw"
      }]
    await TestBed.configureTestingModule({
        imports: [HttpClientTestingModule,ReactiveFormsModule], 
      declarations: [ LoginComponent ],
      providers:[  HttpClientModule,FormBuilder,]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
   localStorage.clear()
    component = fixture.componentInstance;
   fixture.detectChanges();
  });

  
  it('should create', () => {

    mockHttpService.post.and.returnValue(loginres);
  
    fixture.detectChanges(); 
    component.login()
    component.loginForm.value.email= 'jj';
    component.loginForm.value.password='sss';
    component.loginForm.controls['email'].setValue('jj');
    component.loginForm.controls['password'].setValue('jss');   
    expect(component).toBeTruthy();
  });
  
  // it("should call getUsers and return list of users",() => {
    // const response: [] = [];

   

    // component.login();

    // fixture.detectChanges();
  
    // // expect(component.loginresult).toEqual(loginres);
  // });

  // it('should call login ',()=>{

    // component.login()
    
  // })
});
