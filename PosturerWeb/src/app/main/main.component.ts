import { Component, OnInit } from '@angular/core';
import { User } from '../_models/User';
import { UserService, AlertService } from '../_services/index';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  currentUser: User;
  userInfo: User;
  model: any = {};
  passwordMessage: any;
  usernameMessage: any;

  constructor(private userService: UserService,
    private alertService: AlertService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }

  ngOnInit() {
    if (this.currentUser) {
      this.userService.getUserInfo()
        .subscribe(
        data => {
          this.userInfo = data;
        });
    }
  }

  changePassword() {
    this.userService.changePassword(this.model.CurrentPassword, this.model.NewPassword, this.model.NewPassword2)
      .subscribe(
      data => {
        this.userInfo = data;
        this.passwordMessage = {
          type: 'success',
          text: 'Your password was successfully changed'
        };
      },
      error => {
        this.passwordMessage = {
          type: 'error',
          text: this.alertService.getResponse(error.json())
        };
      });
  }

  changeUsername() {
    this.userService.changeUsername(this.model.NewUsername)
      .subscribe(
      data => {
        this.userInfo = data;
        this.usernameMessage = {
          type: 'success',
          text: 'Your username was successfully changed'
        };
      },
      error => {
        this.usernameMessage = {
          type: 'error',
          text: this.alertService.getResponse(error.json())
        };
      });
  }

  formatDate(date: Date): string {
    let d = new Date(date);
    let day = d.getDay();
    let month = d.getMonth() + 1;
    let year = d.getFullYear();

    return month + '/' + day + '/' + year;
  }
}
