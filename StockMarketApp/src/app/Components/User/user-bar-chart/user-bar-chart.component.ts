import { Component, OnInit } from '@angular/core';
import { StockPriceDto } from '../../../models/stock-price-dto';
import {UserService} from '../../../services/user.service'
import { StockPrice } from '../../../models/stock-price';


@Component({
  selector: 'app-user-bar-chart',
  templateUrl: './user-bar-chart.component.html',
  styleUrls: ['./user-bar-chart.component.css']
})
export class UserBarChartComponent implements OnInit {
  item : StockPriceDto;

  constructor(private service:UserService) { 
    this.item = new StockPriceDto();
  
  }
  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public barChartLabels :number [] =[];
  public barChartType = 'line';
  public barChartLegend = true;
  public ChartData : number [] =[];
  public barChartData = [
    {data: this.ChartData, label: 'Charts'},
  ];
  ngOnInit(): void {
  }
  public GetStockPriceList()
  {
    let labels : number[] = [];
    let data : number[] = [];
    this.service.GetStockPriceList(this.item).subscribe((stockPriceList : StockPrice[])=>{
      
      console.log(stockPriceList)
      for(let i=0; i<stockPriceList.length; i++){

        labels.push(stockPriceList[i].Id);
        console.log(stockPriceList[i].Id)
        data.push(stockPriceList[i].CurrentPrice)
      }
      this.barChartLabels = labels;
      this.ChartData = data;
      console.log(labels)
      console.log(data)
    },(err)=>{
      console.log(err.error)
    })
  }
}
