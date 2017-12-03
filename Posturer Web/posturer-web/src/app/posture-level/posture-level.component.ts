import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-posture-level',
  templateUrl: './posture-level.component.html',
  styleUrls: ['./posture-level.component.css']
})
export class PostureLevelComponent implements OnInit {
  chartOptions = {
    responsive: true,
    title: {
      display: false,
      text: 'Posture Levels Chart'
    },
    tooltips: {
      mode: 'index',
      intersect: false,
    },
    hover: {
      mode: 'nearest',
      intersect: true
    },
    scales: {
      xAxes: [{
        display: true,
        scaleLabel: {
          display: true,
          labelString: 'Date'
        }
      }],
      yAxes: [{
        display: true,
        scaleLabel: {
          display: true,
          labelString: 'Value'
        }
      }]
    }
  };

  chartData = [
    { data: [3, 4, 4.25, 3.75, 4.5, 4.6, 4.9], label: 'Posture level', fill: false }
  ];

  chartColors = [
    {
      backgroundColor: 'rgb(54, 162, 235)',
      borderColor: 'rgb(54, 162, 235)'
    },
  ];

  chartLabels = [new Date().toDateString(), "February", "March", "April", "May", "June", "July"];

  onChartClick(event) {
    console.log(event);
  }
  constructor() { }

  ngOnInit() {
  }
}
