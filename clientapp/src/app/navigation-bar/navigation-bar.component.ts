import { AuthenticationService } from './../_services/authentication.service';
import { User } from './../models/user';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent {
  user: User;
  constructor(private auService: AuthenticationService) {
    this.auService.user.subscribe(x => this.user = x);
   }
  LogOut() { 
    this.auService.logout();
  }

}
