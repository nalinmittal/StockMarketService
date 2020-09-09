import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../services/user.service'
import { IpoDetail } from '../../../models/ipo-detail';

@Component({
  selector: 'app-user-ipo',
  templateUrl: './user-ipo.component.html',
  styleUrls: ['./user-ipo.component.css']
})
export class UserIpoComponent implements OnInit {
  ipoDetails : IpoDetail[];
  constructor(private service:UserService) { 
    this.ipoDetails = [];
  }

  ngOnInit(): void {
  }
  public GetIpoList(){
    this.service.GetIpoList().subscribe((ipoDetails : IpoDetail[])=>{
      this.ipoDetails = ipoDetails;
    })
  }
  

}
