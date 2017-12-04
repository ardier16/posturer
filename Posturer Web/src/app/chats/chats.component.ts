import { Component, OnInit } from '@angular/core';
import { Chat } from '../_models/chat';
import { UserService } from '../_services/index';
import { AuthGuard } from '../_guards/index';
import { Message } from '../_models/message';
import { User } from '../_models/User';

@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.css']
})
export class ChatsComponent implements OnInit {
  chats: Chat[];
  messages: Message[];
  currentUser: Object;
  
  constructor(
    private userService: UserService,
    private guard: AuthGuard
  ) { 
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    console.log(this.currentUser);    
  }

  ngOnInit() {
    if (this.guard.canActivate()) {
      this.userService.getChats()
      .subscribe(
          data => {
            this.chats = data;
      });

      this.userService.getMessages(1)
      .subscribe(
          data => {
            this.messages = data;
      });
    }
  }

  formatDate(date: Date): string {
    let d = new Date(date);
    let day = d.getDay();
    let month = d.getMonth();
    let year = d.getFullYear();
    let hours = d.getHours();
    let minutes = d.getMinutes();
    
    return month + '/' + day + '/' + year + ' ' + hours + ':' + 
      (minutes < 10 ? '0' + minutes : minutes);
  }
}
