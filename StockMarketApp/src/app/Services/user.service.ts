import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { StockPriceDto } from '../models/stock-price-dto';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  pathIPO:string="https://localhost:44354/api/ipodetail"
  pathCompany:string="https://localhost:44354/api/company"
  pathStockPrice:string="https://localhost:44354/api/stockprice/chart"

  constructor(private http:HttpClient) { }

  GetIpoList() : Observable<any>
  {
    return this.http.get(this.pathIPO)

  }

  GetStockPriceList(item : StockPriceDto) : Observable<any>
  {
    return this.http.get(this.pathStockPrice+"/"+item.to+"/"+item.from+"/"+item.CompanyId+"/"+item.StockExchangeId);

  }

  GetCompany(id : string) : Observable<Object>
  {
    return this.http.get(this.pathCompany+"?Id="+id)
  }
}
