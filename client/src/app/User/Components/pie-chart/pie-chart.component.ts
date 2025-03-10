import { Component, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { Chart, ChartType, registerables } from 'chart.js';

Chart.register(...registerables); // Register required Chart.js components

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css'],
  standalone: false
})
export class PieChartComponent implements AfterViewInit {
  @ViewChild('pieCanvas') pieCanvas!: ElementRef<HTMLCanvasElement>; // Reference to the canvas
  private pieChart!: Chart;

  ngAfterViewInit() {
    this.createPieChart(); // Initialize the chart after the view is initialized
  }

  createPieChart() {
    this.pieChart = new Chart(this.pieCanvas.nativeElement, {
      type: 'pie' as ChartType, // Chart type
      data: {
        labels: ['Download Sales', 'In-Store Sales', 'Mail-Order Sales'], // Labels for the chart
        datasets: [
          {
            data: [300, 500, 100], // Data for the chart
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
