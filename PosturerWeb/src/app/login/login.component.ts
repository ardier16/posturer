import { Component, OnInit, NgZone } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AlertService, AuthenticationService } from '../_services/index';

@Component({
    selector: 'app-login',
    moduleId: module.id,
    templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
    model: any = {};
    loading = false;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService,
        private zone: NgZone) { }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();
    }

    login() {
        this.loading = true;
        var loginBtn = (<HTMLButtonElement>document.getElementById('login_btn'));
        loginBtn.classList.add('disabled');
        loginBtn.innerHTML = 'Signing In...';

        this.authenticationService.login(this.model.EMail, this.model.Password)
            .subscribe(
            data => {
                this.zone.runOutsideAngular(() => {
                    location.reload();
                });
            },
            error => {
                loginBtn.classList.remove('disabled');
                loginBtn.innerHTML = 'Sign In';
                this.alertService.error(error);
                this.loading = false;
            });
    }
}
