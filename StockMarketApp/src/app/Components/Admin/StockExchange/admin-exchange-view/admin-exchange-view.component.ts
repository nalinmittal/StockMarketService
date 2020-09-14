import { Component, OnInit } from '@angular/core';
import { AdminService } from "../../../../Services/admin.service";
import { ActivatedRoute } from '@angular/router';
import { StockExchange } from "../../../../Models/stock-exchange";

@Component({
  selector: 'app-admin-exchange-view',
  templateUrl: './admin-exchange-view.component.html',
  styleUrls: ['./admin-exchange-view.component.css']
})
export class AdminExchangeViewComponent implements OnInit {

  exchange:StockExchange;
  id:any;

  constructor(private service:AdminService, private _Activatedroute:ActivatedRoute) { this.exchange = new StockExchange(); }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this.View(this.id);
  }

  public View(id:string)
  {
    this.service.GetExchange(id).subscribe(
      (exchange:StockExchange) => {this.exchange = exchange;},
      (err) => {console.log(err)}
    )
  }

}
