import { Component, OnInit } from '@angular/core';
import { User } from '../_models/User';
import { UserService } from '../_services/index';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  currentUser: Object;
  
    constructor(private userService: UserService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }
  ngOnInit() {
  }

}
