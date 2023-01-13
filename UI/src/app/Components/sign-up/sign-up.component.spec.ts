// import { ComponentFixture, TestBed } from '@angular/core/testing';

// import { SignUpComponent } from './sign-up.component';

// describe('SignUpComponent', () => {
//   let component: SignUpComponent;
//   let fixture: ComponentFixture<SignUpComponent>;

//   beforeEach(async () => {
//     await TestBed.configureTestingModule({
//       declarations: [ SignUpComponent ]
//     })
//     .compileComponents();

//     fixture = TestBed.createComponent(SignUpComponent);
//     component = fixture.componentInstance;
//     fixture.detectChanges();
//   });

//   it('should create', () => {
//     expect(component).toBeTruthy();
//   });
// });

import { ComponentFixture, TestBed } from '@angular/core/testing';
import{FormBuilder,}from '@angular/forms';
import {  FormGroup, FormsModule ,ReactiveFormsModule} from "@angular/forms";

import { HttpClientTestingModule } from '@angular/common/http/testing';
import {  HttpClient, HttpClientModule } from '@angular/common/http';
import { LoginModel } from 'src/app/models/loginmodel';
import { of } from 'rxjs';
import { SignUpComponent } from './sign-up.component';


describe('SignupComponent', () => {
  let component: SignUpComponent;
  let fixture: ComponentFixture<SignUpComponent>;
  let mockHttpService: jasmine.SpyObj<HttpClient>;
  let loginres;
  
let User
  beforeEach(async () => {
   
   User=[ {
      userName:"jeyanth",
      email:"jeya",
      password:"jjjj"
      
    },]
    mockHttpService = jasmine.createSpyObj('HttpClient', [
      
      'post',         
    ]);
  
  
      
    await TestBed.configureTestingModule({
        imports: [HttpClientTestingModule], 
      declarations: [ SignUpComponent ],
      providers:[ FormBuilder, HttpClientModule,ReactiveFormsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
  it('should create', () => {
    

    mockHttpService.post.and.returnValue(of(User));
    fixture.detectChanges(); 
     component. signUp()
  
     
      
    expect(component).toBeTruthy();
  });

//   it("should call alert", () => {
    // spyOn(window, "alert");
    // //your code
    // expect(window.alert).toHaveBeenCalledWith("expected message");
//  });  
  
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
