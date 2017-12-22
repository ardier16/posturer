import { Component, OnInit } from '@angular/core';
import { Exercise } from '../../_models/exercise';
import { ExerciseService } from '../../_services/exercise.service';

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html',
  styleUrls: ['./exercises.component.css']
})
export class ExercisesComponent implements OnInit {
  exercises: Exercise[];

  constructor(private exerciseService: ExerciseService) { }

  ngOnInit() {
    this.getExercises();
  }

  getExercises(): void {
    this.exerciseService.getExercises()
      .subscribe(exercises => this.exercises = exercises);
  }
}
