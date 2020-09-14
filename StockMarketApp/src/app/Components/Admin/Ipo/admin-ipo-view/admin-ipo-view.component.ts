import { Component, OnInit } from '@angular/core';
import { IpoDetail } from '../../../../models/ipo-detail';
import { AdminService } from "../../../../Services/admin.service";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-ipo-view',
  templateUrl: './admin-ipo-view.component.html',
  styleUrls: ['./admin-ipo-view.component.css']
})
export class AdminIpoViewComponent implements OnInit {

  ipo:IpoDetail;
  id:any;

  constructor(private service:AdminService, private _Activatedroute:ActivatedRoute) { this.ipo = new IpoDetail(); }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this.View(this.id);
  }

  public View(id:number)
  {
    this.service.GetIpo(id).subscribe(
      (ipo:IpoDetail) => {this.ipo = ipo;},
      (err) => {console.log(err)}
    )
  }
}
