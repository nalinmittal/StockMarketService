import { Component, OnInit } from '@angular/core';
import { Account } from 'src/app/Models/account';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  item:Account;
  constructor(private service:AccountService) {
    this.item=new Account();
   }

  ngOnInit(): void {
  }
  public SignUp()
  {
    console.log(this.item)
    this.service.SignUp(this.item).subscribe(res=>{
      console.log(res)
    },(err)=>{
      console.log(err)
    })
  }
}
