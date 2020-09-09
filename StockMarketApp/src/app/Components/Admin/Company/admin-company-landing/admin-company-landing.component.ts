import { Component, OnInit } from '@angular/core';
import { Company } from "../../../../Models/company";
import { AdminCompanyService } from "../../../../Services/Admin/admin-company.service";

@Component({
  selector: 'app-admin-company-landing',
  templateUrl: './admin-company-landing.component.html',
  styleUrls: ['./admin-company-landing.component.css']
})
export class AdminCompanyLandingComponent implements OnInit 
{

  companies:Company[];

  constructor(private service:AdminCompanyService) { this.companies = [] }

  ngOnInit(): void {
    this.GetAll()
  }

  public GetAll()
  {
    this.service.GetAll().subscribe(
      (companies:Company[]) => 
      {
        this.companies = companies;
        console.log(this.companies)
      },
      (err) =>
      {
        console.log(err)
      }
      )
  }

}
