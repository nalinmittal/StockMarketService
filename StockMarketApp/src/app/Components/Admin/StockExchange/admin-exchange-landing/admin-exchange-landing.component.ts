import { Component, OnInit } from '@angular/core';
import { AdminService } from "../../../../Services/admin.service";
import { StockExchange } from "../../../../Models/stock-exchange";

@Component({
  selector: 'app-admin-exchange-landing',
  templateUrl: './admin-exchange-landing.component.html',
  styleUrls: ['./admin-exchange-landing.component.css']
})
export class AdminExchangeLandingComponent implements OnInit {

  exchanges:StockExchange[];

  constructor(private service:AdminService) { }

  ngOnInit(): void {
    this.GetAll();
  }

  public GetAll()
  {
    this.service.GetAllExchanges().subscribe(
      (exchanges:StockExchange[]) => 
      {
        this.exchanges = exchanges;
        console.log(this.exchanges)
      },
      (err) => {console.log(err)}
      )
  }

}
