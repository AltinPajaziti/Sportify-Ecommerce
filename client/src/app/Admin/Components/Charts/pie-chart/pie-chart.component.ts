

import { Component, AfterViewInit, ElementRef, ViewChild, OnInit } from '@angular/core';
import { Chart, ChartType, registerables } from 'chart.js';
import { GraphicsService } from 'src/app/core/Services/graphics.service';

Chart.register(...registerables); 


@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements AfterViewInit , OnInit{
  @ViewChild('pieCanvas') pieCanvas!: ElementRef<HTMLCanvasElement>; // Reference to the canvas
  private pieChart!: Chart;


 
  constructor(private GraphicService : GraphicsService) {
    
  }

  ngOnInit(): void {
   
  }



  ngAfterViewInit() {
    this.GraphicService.getMonthlySales().subscribe(
      (resp) => {
        console.log("this is the respounse" , resp)

        this.createPieChart(resp.stock , resp.category, resp.purchedproducts); 
      }
    )
  }

  

  createPieChart(Stock : number , Purchesd : number , Category : number) {
    this.pieChart = new Chart(this.pieCanvas.nativeElement, {
      type: 'pie' as ChartType, // Chart type
      data: {
        labels: [ 'Category' ,'In Stock Products','Purchased products ' ], // Labels for the chart
        datasets: [
          {
            data: [Purchesd, Stock, Category], // Data for the chart
            backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'], // Colors for the slices
          },
        ],
      },
      options: {
        responsive: true, // Make it responsive
        plugins: {
          legend: {
            position: 'top', // Position of the legend
          },
        },
      },
    });
  }
}
