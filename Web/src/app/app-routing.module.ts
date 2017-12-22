import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ExercisesComponent } from './components/exercises/exercises.component';
import { ExerciseDetailComponent } from './components/exercise-detail/exercise-detail.component';
import { MainComponent } from './components/main/main.component';
import { ChatsComponent } from './components/chats/chats.component';
import { PostureLevelComponent } from './components/posture-level/posture-level.component';
import { TrainingProgramComponent } from './components/training-program/training-program.component';


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
