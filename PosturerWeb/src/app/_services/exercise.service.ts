import { Injectable } from '@angular/core';
import { Exercise } from '../_models/exercise';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ExerciseService {
  private exercisesUrl = 'http://posturer.azurewebsites.net/api/exercises';

  constructor(
    private http: HttpClient) { }


  getExercises(): Observable<Exercise[]> {
    return this.http.get<Exercise[]>(this.exercisesUrl);
  }

  getExercise(id: number): Observable<Exercise> {
    return this.http.get<Exercise>(this.exercisesUrl + '/' + id);
  }

}
