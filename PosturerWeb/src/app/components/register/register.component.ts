import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AlertService, UserService } from '../../_services/index';

@Component({
    selector: 'app-register',
    moduleId: module.id,
    templateUrl: 'register.component.html'
})

export class RegisterComponent {
    model: any = {};
    loading = false;

    constructor(
        private router: Router,
        private userService: UserService,
        private alertService: AlertService) { }

    ngOnInit() {
    }

    register() {
        this.loading = true;
        var registerBtn = (<HTMLButtonElement>document.getElementById('register_btn'));
        registerBtn.classList.add('disabled');
        registerBtn.innerHTML = 'Signing Up...';

        this.userService.register({ EMail: this.model.EMail, Password: this.model.Password })
            .subscribe(
            data => {
                registerBtn.classList.remove('disabled');
                registerBtn.innerHTML = 'Sign Up';
                this.alertService.success('You\'ve successfully signed up!', true);
                this.router.navigate(['/login']);
            },
            error => {
                registerBtn.classList.remove('disabled');
                registerBtn.innerHTML = 'Sign Up';
                this.alertService.error(error);
                this.loading = false;
            });
    }
}