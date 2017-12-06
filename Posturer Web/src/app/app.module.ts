import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';


import { AppComponent } from './app.component';
import { ExercisesComponent } from './exercises/exercises.component';
import { ExerciseDetailComponent } from './exercise-detail/exercise-detail.component';
import { ExerciseService } from './_services/exercise.service';
import { AppRoutingModule } from './/app-routing.module';
import { MainComponent } from './main/main.component';
import { ChatsComponent } from './chats/chats.component';
import { PostureLevelComponent } from './posture-level/posture-level.component';
import { TrainingProgramComponent } from './training-program/training-program.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AlertService, AuthenticationService, UserService } from './_services/index';
import { AlertComponent } from './alert/alert.component';
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
