import { Component, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { Chart } from 'chart.js';
import { GraphicsService } from 'src/app/core/Services/graphics.service';

@Component({
  selector: 'app-app-monthly-orders-chart',
  templateUrl: './app-monthly-orders-chart.component.html',
  styleUrls: ['./app-monthly-orders-chart.component.css']
})
export class AppMonthlyOrdersChartComponent implements AfterViewInit {
  @ViewChild('ordersCanvas') ordersCanvas!: ElementRef<HTMLCanvasElement>;
  private ordersChart!: Chart;

  thisYearData: number[] = [];
  lastYearData: number[] = [];

  constructor(private graphicService: GraphicsService) {}

  ngAfterViewInit() {
    this.fetchSalesData(); // Fetch data when component is initialized
  }

  // Fetch data from the GraphicsService
  fetchSalesData() {
    this.graphicService.getYearlySales().subscribe(
      (data) => {
        this.processSalesData(data);
        this.createOrdersChart();
      },
      (error) => {
        console.error('Error fetching sales data', error);
      }
    );
  }

  // Process the sales data to extract the monthly sales for both years
  processSalesData(data: any) {
    // Initialize arrays to hold monthly sales data for both years
    this.thisYearData = Array(12).fill(0); // Default sales for this year (0 for all months)
    this.lastYearData = Array(12).fill(0); // Default sales for last year (0 for all months)

    // Fill in the actual sales data for this year
    data.thisYear.forEach((sales: { month: number; totalSales: number }) => {
      this.thisYearData[sales.month - 1] = sales.totalSales; // Adjust for zero-based index
    });

    // Fill in the actual sales data for last year
    data.lastYear.forEach((sales: { month: number; totalSales: number }) => {
      this.lastYearData[sales.month - 1] = sales.totalSales; // Adjust for zero-based index
    });
  }

  // Create the chart with the data
  createOrdersChart() {
    this.ordersChart = new Chart(this.ordersCanvas.nativeElement, {
      type: 'bar', // Change to 'line' if you want a line chart
      data: {
        labels: [
          'January', 'February', 'March', 'April', 'May', 'June', 
          'July', 'August', 'September', 'October', 'November', 'December'
        ], // Months
        datasets: [
          {
            label: 'Orders This Year',
            data: this.thisYearData, // Orders for each month of this year
            backgroundColor: '#36A2EB', // Bar color
            borderColor: '#36A2EB', // Border color for bars
            borderWidth: 1, // Border width
          },
          {
            label: 'Orders Last Year',
            data: this.lastYearData, // Orders for each month of last year
            backgroundColor: '#FF6384', // Bar color for last year's data
            borderColor: '#FF6384',
            borderWidth: 1,
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true, // Start y-axis at 0
            title: {
              display: true,
              text: 'Number of Orders',
            },
          },
          x: {
            title: {
              display: true,
              text: 'Months',
            },
          },
        },
        plugins: {
          legend: {
            position: 'top', // Legend position
          },
          tooltip: {
            callbacks: {
              label: (context) => {
                return `${context.dataset.label}: ${context.raw} orders`; // Custom tooltip text
              },
            },
          },
        },
      },
    });
  }
}
