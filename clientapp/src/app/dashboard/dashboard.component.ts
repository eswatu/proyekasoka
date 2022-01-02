import { ApiResult } from './../_services/base.service';
import { User } from './../models/user';
import { JobOrderService } from './../_services/job-order.service';
import { Joborder } from './../models/joborder';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  joborders : Joborder[];
  currentUser: User;
  defaultPageSize = 10;
  constructor(private joborderservice: JobOrderService, private authService: AuthenticationService) { 
    this.authService.user.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {
    this.getData();
  }
  getData() {
    var filterColumn =  null;
    var filterQuery =  null;
  
    this.joborderservice.getCompleteData<ApiResult<Joborder>>(
      0,this.defaultPageSize,
      "namaKlien", "asc",
      filterColumn,
      filterQuery,
      "null", "null",
    this.currentUser.id.toString())
      .subscribe(result => {
        this.joborders = result.data;
      }, error => console.error(error));
  }
  
}
