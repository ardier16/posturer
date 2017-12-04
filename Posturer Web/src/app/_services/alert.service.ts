import { Injectable } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class AlertService {
    private subject = new Subject<any>();
    private keepAfterNavigationChange = false;

    constructor(private router: Router) {
        // clear alert message on route change
        router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                if (this.keepAfterNavigationChange) {
                    // only keep for a single location change
                    this.keepAfterNavigationChange = false;
                } else {
                    // clear alert
                    this.subject.next();
                }
            }
        });
    }

    success(message: string, keepAfterNavigationChange = false) {
        this.keepAfterNavigationChange = keepAfterNavigationChange;
        this.subject.next({ type: 'success', text: message });
    }

    error(error: any, keepAfterNavigationChange = false) {
        this.keepAfterNavigationChange = keepAfterNavigationChange;

        console.log(error['status']);

        if (error["status"] == '200') {
            this.subject.next({ type: 'success', text: "Success" });            
        } else if (error.status = '400') {
            this.subject.next({ type: 'error', text: this.getResponse(error.json()) });            
        }
    }


    getResponse(response : Object) {
        let result : String = '';
        
        if (response["error_description"]) {
            return response["error_description"];
        }

        else if (response["ModelState"]) {
            for (var key in response["ModelState"]) {
                result += response["ModelState"][key];
            }
        }
    
        return result.split(',')[0];
    }

    getMessage(): Observable<any> {
        return this.subject.asObservable();
    }
}