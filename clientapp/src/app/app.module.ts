import { JoblistComponent } from './dashboard/joblist/joblist.component';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { AuthenticationService } from './_services/authentication.service';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { MaterialModule } from './material.module';
import { LaporanComponent } from './laporan/laporan.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DetilLaporanComponent } from './laporan/detil-laporan/detil-laporan.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { DatePipe } from '@angular/common';
import { appInitializer } from './_helpers';
import { LoginComponent } from './login/login.component';
import { JobSummaryComponent } from './dashboard/job-summary/job-summary.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    NavigationBarComponent,
    LaporanComponent,
    DetilLaporanComponent,
    LoginComponent,
    JoblistComponent,
    JobSummaryComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [DatePipe,
    { provide: APP_INITIALIZER, useFactory: appInitializer, multi: true, deps: [AuthenticationService] },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
