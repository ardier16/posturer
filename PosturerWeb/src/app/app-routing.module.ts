import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ExercisesComponent } from './exercises/exercises.component';
import { ExerciseDetailComponent } from './exercise-detail/exercise-detail.component';
import { MainComponent } from './main/main.component';
import { ChatsComponent } from './chats/chats.component';
import { PostureLevelComponent } from './posture-level/posture-level.component';
import { TrainingProgramComponent } from './training-program/training-program.component';


const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'exercises', component: ExercisesComponent },
  { path: 'exercises/:id', component: ExerciseDetailComponent },
  { path: 'chats', component: ChatsComponent },
  { path: 'posture-level', component: PostureLevelComponent },
  { path: 'training-program', component: TrainingProgramComponent },

  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
