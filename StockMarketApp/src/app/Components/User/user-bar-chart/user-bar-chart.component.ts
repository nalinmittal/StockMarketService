import { Component, OnInit, ViewChild } from '@angular/core';
import { StockPriceDto } from '../../../models/stock-price-dto';
import {UserService} from '../../../services/user.service'
import { StockPrice } from '../../../models/stock-price';
import { Label, BaseChartDirective } from 'ng2-charts';



@Component({
  selector: 'app-user-bar-chart',
  templateUrl: './user-bar-chart.component.html',
  styleUrls: ['./user-bar-chart.component.css']
})
export class UserBarChartComponent implements OnInit {
  item : StockPriceDto;
  @ViewChild(BaseChartDirective) chart: BaseChartDirective;

  constructor(private service:UserService) { 
    this.item = new StockPriceDto();
  
  }
  
  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  public barChartLabels :number[]=[];
  public barChartType = 'line';
  public barChartLegend = true;

  public barChartData = [
    
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

        labels.push(stockPriceList[i].id);
        //console.log(stockPriceList[i].id)
        data.push(stockPriceList[i].currentPrice)
      }
      this.barChartLabels = labels;
      //this.ChartData = data;
      var a = {data: data, label:'Chart'};
      //this.barChartData.push(a);
      this.Refresh(a);
      //console.log(this.barChartLabels)
      //console.log(this.barChartData[0].data)
      
    },(err)=>{
      console.log(err.error)
    })
  }
  public Refresh(a){
    this.barChartData.push(a);
    this.chart.chart.update();
    //console.log("Please work")
  }

  
}
