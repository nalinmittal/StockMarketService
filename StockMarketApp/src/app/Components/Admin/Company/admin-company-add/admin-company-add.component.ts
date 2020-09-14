import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../../Services/admin.service'
import { Company } from '../../../../Models/company';
import { StockExchange } from "../../../../Models/stock-exchange";
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-admin-company-add',
  templateUrl: './admin-company-add.component.html',
  styleUrls: ['./admin-company-add.component.css']
})
export class AdminCompanyAddComponent implements OnInit {

  myForm:FormGroup;
    company:Company;
    exchanges:any = [];
    disabled = false;
    ShowFilter = true;
    limitSelection = false;
    selectedItems:any = [];
    dropdownSettings:any = {};


  constructor(private service:AdminService, private fb:FormBuilder) 
  { 
    this.company = new Company(); 
  }

  ngOnInit(): void {
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

  public AddCompany()
  {
    this.service.AddCompany(this.company).subscribe(
      (res) => {console.log(res)},
      (err) => {console.log(err)}
    )
  }
}
