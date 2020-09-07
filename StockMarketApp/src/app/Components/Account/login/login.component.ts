import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account';
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor((private service:AccountService,private router:Router) { 
    localStorage.clear();
  }

  ngOnInit() {
  }
  Validate()
  {
    this.service.Validate('Admin','12345').subscribe(res=>{
      if(res.usertype=='Admin')
      {
        localStorage.setItem('token',res.token)
      console.log(res)
      this.router.navigateByUrl('item');
      }
      else if(res.token==""||res.token==null)
      {
        console.log('Invalid Id');
      }
      else
      {
      localStorage.setItem('token',res.token)
      console.log(res)
      this.router.navigateByUrl('item');
      }
    })
  }

