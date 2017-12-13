import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {
    constructor(private http: Http) { }
    // API URL for accessing Bearer Authentication Token
    private loginUrl = 'http://posturer.azurewebsites.net/token';

    login(email: string, password: string) {
        return this.http.post(this.loginUrl, 'userName=' + email + '&password=' + password + '&grant_type=password')
            .map((response: Response) => {
                // Getting response data
                let user = response.json();

                // Response returned Access Token
                if (user && user.access_token) {
                    // Set Access Token as local storage item for
                    // being authenticated when reloading
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
            });
    }

    logout() {
        localStorage.removeItem('currentUser');
    }
}