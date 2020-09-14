import { Component, OnInit } from '@angular/core';
import { Company } from "../../../../Models/company";
import { ActivatedRoute } from '@angular/router';
import { AdminService } from "../../../../Services/admin.service";
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-admin-company-update',
  templateUrl: './admin-company-update.component.html',
  styleUrls: ['./admin-company-update.component.css']
})
export class AdminCompanyUpdateComponent implements OnInit {

  id:any;

  myForm:FormGroup;
    company:Company;
    exchanges:any = [];
    disabled = false;
    ShowFilter = true;
    limitSelection = false;
    selectedItems:any = [];
    dropdownSettings:any = {};


  constructor(private service:AdminService, private fb:FormBuilder, private _Activatedroute:ActivatedRoute) 
  { 
    this.company = new Company(); 
  }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this.View(this.id);
    this.GetAllExchanges();
    this.dropdownSettings = {
      singleSelection:false,
      idField:"stockexchange",
      textField:"stockexchange",
      selectAllText:"Select All",
      unSelectAllText:"Unselect All",
      allowSearchFilter:this.ShowFilter
    };
    this.myForm = this.fb.group({
      exchange : [this.selectedItems]
    });
  }

  onItemSelect(item:any){
    console.log('onItemSelect',item);
  }

  onSelectAll(items:any){
    console.log('onSelectAll',items);
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

  public UpdateCompany()
  {
    console.log(this.company)
    this.service.UpdateCompany(this.id,this.company).subscribe(
      (res) => {console.log(res)},
      (err) => {console.log(err)}
    )
  }

  public View(id:number)
  {
    this.service.GetCompany(id).subscribe(
      (company:Company) => {this.company = company;},
      (err) => {console.log(err)}
    )
  }

}
