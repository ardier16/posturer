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
  currentChat: Chat;
  messages: Message[];
  currentUser: User;
  pressedKeys = {};

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
    }
  }

  formatDate(date: Date): string {
    let d = new Date(date);
    let day = d.getDate();
    let month = d.getMonth();
    let year = d.getFullYear();
    let hours = d.getHours();
    let minutes = d.getMinutes();

    return month + '/' + day + '/' + year + ' ' + hours + ':' +
      (minutes < 10 ? '0' + minutes : minutes);
  }

  showMessages(chatId: number) {
    this.currentChat = this.findChat(chatId);

    this.userService.getMessages(chatId)
      .subscribe(
      data => {
        this.messages = data;
        this.scrollToChatBottom();
      });

  }

  scrollToChatBottom() {
    var chat = document.getElementsByClassName("chat_area")[0];
    if (chat) {
      setTimeout(() => {
        chat.scrollTop = chat.scrollHeight;
      }, 50);
    };
  }

  sendMessage() {
    let textArea = (<HTMLTextAreaElement>document.getElementById('message_text'));

    if (textArea.value.trim() != '') {
      let text = textArea.value;
      textArea.value = '';

      let message: Message = {
        MessageId: 0,
        Text: text,
        UserName: this.currentUser.UserName,
        SentDate: new Date()
      }

      this.messages.push(message);
      this.scrollToChatBottom();

      this.userService.sendMessage(this.currentChat.ChatId, text).subscribe(
        data => {
          this.showMessages(this.currentChat.ChatId);
        }
      );
    }

  }

  findChat(id: number): Chat {
    for (let c of this.chats) {
      if (c.ChatId === id) {
        return c;
      }
    }
  }

  keyDown(event) {
    this.pressedKeys[event.keyCode] = true;

    if (this.pressedKeys[13] && this.pressedKeys[17]) {
      this.sendMessage();
      return;
    }
  }

  keyUp(event) {
    delete this.pressedKeys[event.keyCode];
  }
}
