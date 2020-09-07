import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Account, UserType } from '../Models/account';
import { Observable } from 'rxjs';
import { Token } from '../token';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  path:string="http://localhost:44336/Account/"
  url:string='http://localhost:44336/Login/Validate/'

  constructor(private http:HttpClient) { }
  public SignUp(item:Account)
  {
    return this.http.post(this.path+"SignUp",item)
  }
  public Validate(usertype:UserType,pwd:string):Observable<Token>
  {
    return this.http.get<Token>(this.url+usertype+'/'+pwd);
  }
}
