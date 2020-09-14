import { Component, OnInit } from '@angular/core';
import { Company } from "../../../../Models/company";
import { AdminService } from "../../../../Services/admin.service";

@Component({
  selector: 'app-admin-company-landing',
  templateUrl: './admin-company-landing.component.html',
  styleUrls: ['./admin-company-landing.component.css']
})
export class AdminCompanyLandingComponent implements OnInit 
{

  companies:Company[];

  constructor(private service:AdminService) { this.companies = [] }

  ngOnInit(): void {
    this.GetAll()
  }

  public GetAll()
  {
    this.service.GetAllCompanies().subscribe(
      (companies:Company[]) => 
      {
        this.companies = companies;
        console.log(this.companies)
      },
      (err) => {console.log(err)}
      )
  }

  public Delete(id:number)
  {
    this.service.DeleteCompany(id).subscribe(
      (res) => {
        console.log(res);
        this.GetAll();},
      (err) => {console.log(err);}
    )
  }

}
