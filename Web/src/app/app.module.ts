import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';


import { AppComponent } from './app.component';
import { ExercisesComponent } from './components/exercises/exercises.component';
import { ExerciseDetailComponent } from './components/exercise-detail/exercise-detail.component';
import { ExerciseService } from './_services/exercise.service';
import { AppRoutingModule } from './/app-routing.module';
import { MainComponent } from './components/main/main.component';
import { ChatsComponent } from './components/chats/chats.component';
import { PostureLevelComponent } from './components/posture-level/posture-level.component';
import { TrainingProgramComponent } from './components/training-program/training-program.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AlertService, AuthenticationService, UserService } from './_services/index';
import { AlertComponent } from './components/alert/alert.component';
import { AuthGuard } from './_guards/index';


@NgModule({
  declarations: [
    AppComponent,
    ExercisesComponent,
    ExerciseDetailComponent,
    MainComponent,
    ChatsComponent,
    PostureLevelComponent,
    TrainingProgramComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    AlertComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ChartsModule,
    
    HttpModule,
    HttpClientModule
  ],
  providers: [
    AuthGuard,
    ExerciseService,
    AlertService,
    AuthenticationService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
