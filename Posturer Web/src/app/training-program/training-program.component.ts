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
  trainingProgram: TrainingProgram;

  constructor(
      private userService : UserService,
      private guard: AuthGuard) { }

  ngOnInit() {
    if (this.guard.canActivate()) {
      this.userService.getTrainingProgram()
      .subscribe(
          data => {
            this.trainingProgram = data;
    }
  }

}
