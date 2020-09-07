import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { Account } from 'src/app/Models/account';
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  item:Account;
  constructor(private service:AccountService,private router:Router) { 
    this.item=new Account();
    localStorage.clear();
  }

  ngOnInit() {
  }
  Validate()
  {
    
  }
}
