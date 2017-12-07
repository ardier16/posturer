import { Component, OnInit, NgZone } from '@angular/core';
import { UserService } from '../_services/index';
import { Location } from '@angular/common';
import { AuthenticationService } from '../_services/index';


@Component({
  selector: 'navbar-section',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  currentUser: Object;
  location: Location;

  constructor(
    private userService: UserService,
    location: Location,
    private authenticationService: AuthenticationService,
    private zone: NgZone
  ) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.location = location;
  }

  ngOnInit() {
  }

  getClass(href: string): string {
    return this.location.path().substr(0, href.length) === href ? 'nav-item active' : 'nav-item';
  }

  logout(): void {
    this.authenticationService.logout();
    this.zone.runOutsideAngular(() => {
      location.href = '';
    });
  }

}
