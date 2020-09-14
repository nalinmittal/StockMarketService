import { Component, OnInit } from '@angular/core';
import { AdminService } from "../../../../Services/admin.service";
import { IpoDetail } from '../../../../models/ipo-detail';
import { Company } from "../../../../models/company";

@Component({
  selector: 'app-admin-ipo-add',
  templateUrl: './admin-ipo-add.component.html',
  styleUrls: ['./admin-ipo-add.component.css']
})
export class AdminIpoAddComponent implements OnInit {

  companies:any = [];
  exchanges:any = [];
  ipo:IpoDetail;

  constructor(private service:AdminService) { this.ipo = new IpoDetail(); }

  ngOnInit(): void {
    this.GetAllExchanges();
    this.GetAllCompanies();
  }

  public GetAllExchanges()
  {
    this.service.GetExchangeNames().subscribe(
      (exchanges:string[]) => 
      {
        this.exchanges = exchanges;
        console.log(this.exchanges)
      },
      (err) => {console.log(err)}
      )
  }
  public GetAllCompanies()
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

  public AddIpo()
  {
    this.ipo.companyId = Number(this.ipo.companyId);
    console.log(this.ipo)
    this.service.AddIpo(this.ipo).subscribe(
      (res) => {console.log(res)},
      (err) => {console.log(err)}
    )
  }


}
