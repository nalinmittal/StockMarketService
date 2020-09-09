import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminCompanyService 
{

  path:string = "http://localhost:1601/admin/company"

  constructor(private http:HttpClient) { }

  GetAll() : Observable<any>
  {
    return this.http.get(this.path)
  }

}
