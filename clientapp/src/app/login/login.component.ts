import { AuthenticationService } from './../_services/authentication.service';
import { BaseFormComponent } from '../models/base.form.component';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent extends BaseFormComponent implements OnInit {

  override form: FormGroup;

  loading = false;
  returnUrl: string;
  error = '';

  constructor(
      private route: ActivatedRoute,
      private router: Router,
      private authenticationService: AuthenticationService
  ) { 
    super();
      // redirect to home if already logged in
      if (this.authenticationService.userValue) { 
          this.router.navigate(['/']);
      }
  }

  ngOnInit() {
      this.form = new FormGroup({
          username: new FormControl('', Validators.required),
          password: new FormControl('', Validators.required)
      });

      // get return url from route parameters or default to '/'
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
      // stop here if form is invalid
      if (this.form.invalid) {
          return;
      }

      this.loading = true;
      this.authenticationService.login(this.form.get('username').value, this.form.get('password').value)
          .pipe(first())
          .subscribe({
              next: () => {
                  this.router.navigate([this.returnUrl]);
              },
              error: error => {
                  this.error = error;
                  this.loading = false;
              }
          });
  }
}