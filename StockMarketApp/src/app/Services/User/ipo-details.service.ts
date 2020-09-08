import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IpoDetailsService {

  path:string="https://localhost:44354/api/ipodetail"

  constructor(private http:HttpClient) { }

  GetIpoList() : Observable<any>
  {
    return this.http.get(this.path)

  }
}
