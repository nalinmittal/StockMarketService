import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Company } from '../models/company';
import { IpoDetail } from '../models/ipo-detail';
import { StockExchange } from '../Models/stock-exchange';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  companyPath:string = "http://localhost:1601/admin/company"
  ipoPath:string = "http://localhost:1601/admin/ipo"
  exchangePath:string = "http://localhost:1601/admin/stockexchange"
  uploadPath:string = "http://localhost:1601/upload"

  constructor(private http:HttpClient) { }

  public GetAllCompanies() : Observable<any>
  {
    return this.http.get(this.companyPath);
  }

  public GetCompany(id:number) : Observable<any>
  {
    return this.http.get(this.companyPath+"/"+id);
  }

  public DeleteCompany(id:number) : Observable<any>
  {
    return this.http.delete(this.companyPath+"/"+id);
  }

  public AddCompany(company:Company) : Observable<any>
  {
    return this.http.post(this.companyPath,company);
  }

  public GetCompanyNames() : Observable<any>
  {
    return this.http.get(this.companyPath+"/names");
  }

  public UpdateCompany(id:number,company:Company) : Observable<any>
  {
    return this.http.put(this.companyPath+"/"+id,company);
  }

  public GetAllIpos() : Observable<any>
  {
    return this.http.get(this.ipoPath);
  }

  public GetIpo(id:number) : Observable<any>
  {
    return this.http.get(this.ipoPath+"/"+id);
  }

  public AddIpo(ipo:IpoDetail) : Observable<any>
  {
    return this.http.post(this.ipoPath,ipo);
  }

  public GetAllExchanges() : Observable<any>
  {
    return this.http.get(this.exchangePath);
  }

  public GetExchange(id:string) : Observable<any>
  {
    return this.http.get(this.exchangePath+"/"+id);
  }

  public GetExchangeNames() : Observable<any>
  {
    return this.http.get(this.exchangePath+"/names");
  }

  public AddExchange(exchange:StockExchange) : Observable<any>
  {
    return this.http.post(this.exchangePath,exchange);
  }

}
