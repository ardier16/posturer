import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services';
import { PostureLevel } from '../_models/posture-level';
import { Chart } from 'chart.js';
import { AuthGuard } from '../_guards/index';


@Component({
  selector: 'app-posture-level',
  templateUrl: './posture-level.component.html',
  styleUrls: ['./posture-level.component.css']
})
export class PostureLevelComponent implements OnInit {
  postureLevels: PostureLevel[];
  chartOptions = {

  };

  constructor(private userService: UserService,
    private guard: AuthGuard) {

  }

  ngOnInit() {
    if (this.guard.canActivate()) {
      this.userService.getPostureLevel()
        .subscribe(
        data => {
          this.postureLevels = data;
          let ctx = document.getElementById('chart');
          let chart = new Chart(ctx, {
            type: 'line',
            data: {
              labels: this.postureLevels.map(p => this.formatDate(p.Date)),
              datasets: [{
                label: 'Posture Level',
                data: this.postureLevels.map(p => p.Level),
                fill: false,
                backgroundColor: 'rgb(54, 162, 235)',
                borderColor: 'rgb(54, 162, 235)',
                borderWidth: 3
              }]
            },
            options: {
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
                  },
                  ticks: {
                    beginAtZero: true,
                    suggestedMax: 5 
                  }
                }]
              }
            }
          });
        });
    }
  }

  formatDate(date: Date): string {
    let d = new Date(date);
    let day = d.getDate();
    let month = d.getMonth() + 1;
    let year = d.getFullYear();

    return month + '/' + day + '/' + year;
  }
}
