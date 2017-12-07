import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services';
import { AuthGuard } from '../_guards/index';
import { TrainingProgram } from '../_models/training-program';

@Component({
  selector: 'app-training-program',
  templateUrl: './training-program.component.html',
  styleUrls: ['./training-program.component.css']
})
export class TrainingProgramComponent implements OnInit {
  trainingProgram: TrainingProgram = {
    TrainingProgramId: 0,
    UserId: '',
    Exercises: null
  };

  constructor(
    private userService: UserService,
    private guard: AuthGuard) { }

  ngOnInit() {
    if (this.guard.canActivate()) {
      this.userService.getTrainingProgram()
        .subscribe(
        data => {
          this.trainingProgram = data;
        });
    }
  }

  getNewProgram() {
    var programButton = (<HTMLButtonElement>document.getElementById('new_program_btn'));
    programButton.className = "btn btn-success disabled";
    programButton.innerHTML = "Getting new program..."

    if (this.guard.canActivate()) {
      this.userService.getNewTrainingProgram()
        .subscribe(
        data => {
          this.trainingProgram = data;
          programButton.className = "btn btn-success";
          programButton.innerHTML = "Get new program"

        });

    }
  }
}
