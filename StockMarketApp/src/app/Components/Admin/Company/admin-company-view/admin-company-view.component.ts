import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from '../../../../Models/company';
import { AdminService } from '../../../../Services/admin.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-admin-company-view',
  templateUrl: './admin-company-view.component.html',
  styleUrls: ['./admin-company-view.component.css']
})
export class AdminCompanyViewComponent implements OnInit {

  company:Company;
  id:any;
  constructor(private service:AdminService, private _Activatedroute:ActivatedRoute) { this.company = new Company(); }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this.View(this.id);
  }

  
  public View(id:number)
  {
    this.service.GetCompany(id).subscribe(
      (company:Company) => {this.company = company;},
      (err) => {console.log(err)}
    )
  }

}
