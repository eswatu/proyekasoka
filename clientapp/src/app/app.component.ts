import { User } from './models';
import { AuthenticationService } from './_services';

import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  template: `
  <div fxLayout="column" fxFill>
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
      rel="stylesheet">
    <div fxFlex="7" static>
        <navigation-bar></navigation-bar>
    </div>
    <div fxFlex="93">
    <router-outlet></router-outlet>
    </div>
  </div>
`
})
export class AppComponent {
  user: User;
  constructor(private authenticationService: AuthenticationService) {
    this.authenticationService.user.subscribe(x => this.user = x);
  }
}