import { Component, ElementRef, ViewChild } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-app-monthly-orders-chart',
  templateUrl: './app-monthly-orders-chart.component.html',
  styleUrls: ['./app-monthly-orders-chart.component.css'],
  standalone: false
})

export class AppMonthlyOrdersChartComponent {
  @ViewChild('ordersCanvas') ordersCanvas!: ElementRef<HTMLCanvasElement>;
  private ordersChart!: Chart;

  ngAfterViewInit() {
    this.createOrdersChart();
  }

  createOrdersChart() {
    this.ordersChart = new Chart(this.ordersCanvas.nativeElement, {
      type: 'bar', // Change to 'line' if you want a line chart
      data: {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'], // Months
        datasets: [
          {
            label: 'Orders This Year',
            data: [50, 75, 100, 125, 150, 175, 200], // Orders for each month
            backgroundColor: '#36A2EB', // Bar color
            borderColor: '#36A2EB', // Border color for bars
            borderWidth: 1, // Border width
          },
          {
            label: 'Orders Last Year',
            data: [40, 60, 80, 110, 130, 160, 190], // Comparison data
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
