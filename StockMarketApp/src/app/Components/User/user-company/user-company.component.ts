import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../services/user.service'
import { Company } from '../../../Models/company';

@Component({
  selector: 'app-user-company',
  templateUrl: './user-company.component.html',
  styleUrls: ['./user-company.component.css']
})
export class UserCompanyComponent implements OnInit {
  item : Company
  Id : string
  constructor(private service:UserService) 
  {
    this.item = new Company();
  }

  ngOnInit(): void {
  }
  public GetCompany()
  {
    this.service.GetCompany(this.Id).subscribe((item:Company)=>{
      this.item=item[0]
      console.log(this.item)
    },(err)=>{
      console.log(err.error)
    })
  }
  

}
