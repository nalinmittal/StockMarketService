import { Component, OnInit } from '@angular/core';
import { IpoDetail } from '../../../../Models/ipo-detail'
import { AdminService } from "../../../../Services/admin.service";

@Component({
  selector: 'app-admin-ipo-landing',
  templateUrl: './admin-ipo-landing.component.html',
  styleUrls: ['./admin-ipo-landing.component.css']
})
export class AdminIpoLandingComponent implements OnInit {

  ipos:IpoDetail[];

  constructor(private service:AdminService) { }

  ngOnInit(): void {
    this.GetAll();
  }

  public GetAll()
  {
    this.service.GetAllIpos().subscribe(
      (ipos:IpoDetail[]) => 
      {
        this.ipos = ipos;
        console.log(this.ipos)
      },
      (err) => {console.log(err)}
      )
  }
}
