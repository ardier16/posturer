import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { User } from '../_models/User';

@Injectable()
export class UserService {
    constructor(private http: Http) { }

    private apiUrl = 'http://localhost:61538/api/';

    register(user: any) {
        return this.http.post(this.apiUrl + 'account/register', {
            "EMail": user.EMail,
            "Password": user.Password
        }, this.content()).map((response: Response) => response.json());
    }

    getPostureLevel() {
        return this.http.get(this.apiUrl + 'posturelevel', this.jwt()).map((response: Response) => response.json());
    }

    getTrainingProgram() {
        return this.http.get(this.apiUrl + 'trainingprogram', this.jwt()).map((response: Response) => response.json());
    }

    getChats() {
        return this.http.get(this.apiUrl + 'chat/chats', this.jwt()).map((response: Response) => response.json());
    }

    getMessages(id: number) {
        return this.http.get(this.apiUrl + 'chat/' + id, this.jwt()).map((response: Response) => response.json());
    }

    getUserInfo() {
        return this.http.get(this.apiUrl + 'account/userinfo', this.jwt()).map((response: Response) => response.json());
    }

    sendMessage(chatId: number, text: string) {
        return this.http.post(this.apiUrl + 'chat/' + chatId, {
            "Text": text
        }, this.jwt()).map((response: Response) => response.json());
    }

    getNewTrainingProgram() {
        return this.http.post(this.apiUrl + 'trainingprogram', {}, this.jwt()).map((response: Response) => response.json());
    }

    changePassword(oldPass: string, newPass: string, confirmPass: string) {
        return this.http.post(this.apiUrl + 'account/changepassword', {
            "OldPassword": oldPass,
            "NewPassword": newPass,
            "ConfirmPassword": confirmPass
        }, this.jwt()).map((response: Response) => response.json());
    }

    changeUsername(userName: string) {
        return this.http.post(this.apiUrl + 'account/changeusername', {
            "UserName": userName,
        }, this.jwt()).map((response: Response) => response.json());
    }

    // private helper methods

    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.access_token) {
            let headers = new Headers({
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + currentUser.access_token
            });
            return new RequestOptions({ headers: headers });
        }
    }

    private content() {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        return new RequestOptions({ headers: headers });
    }
}