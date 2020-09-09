import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  pathIPO:string="https://localhost:44354/api/ipodetail"
  pathCompany:string="https://localhost:44354/api/company"

  constructor(private http:HttpClient) { }

  GetIpoList() : Observable<any>
  {
    return this.http.get(this.pathIPO)

  }

  GetCompany(id : string) : Observable<Object>
  {
    return this.http.get(this.pathCompany+"?Id="+id)
  }
}
