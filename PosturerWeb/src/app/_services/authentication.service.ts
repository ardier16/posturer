import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {
    constructor(private http: Http) { }
    private loginUrl = 'http://posturer.azurewebsites.net/token';

    login(email: string, password: string) {
        return this.http.post(this.loginUrl, 'userName=' + email + '&password=' + password + '&grant_type=password')
            .map((response: Response) => {
                let user = response.json();
                if (user && user.access_token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
                else {
                }
            });
    }

    logout() {
        localStorage.removeItem('currentUser');
    }
}