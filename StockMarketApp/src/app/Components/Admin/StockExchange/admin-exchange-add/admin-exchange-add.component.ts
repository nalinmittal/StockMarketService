import { Component, OnInit } from '@angular/core';
import { AdminService } from "../../../../Services/admin.service";
import { StockExchange } from '../../../../Models/stock-exchange';


@Component({
  selector: 'app-admin-exchange-add',
  templateUrl: './admin-exchange-add.component.html',
  styleUrls: ['./admin-exchange-add.component.css']
})
export class AdminExchangeAddComponent implements OnInit {

  exchange:StockExchange;

  constructor(private service:AdminService) { this.exchange = new StockExchange(); }

  ngOnInit(): void {
  }

  public AddExchange()
  {
    this.service.AddExchange(this.exchange).subscribe(
      (res) => {console.log(res)},
      (err) => {console.log(err)}
    )
  }

}
