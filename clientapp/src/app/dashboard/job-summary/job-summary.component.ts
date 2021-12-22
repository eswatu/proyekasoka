import { JobTrack } from './../../models/jobTrack';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-job-summary',
  templateUrl: './job-summary.component.html',
  styleUrls: ['./job-summary.component.css']
})
export class JobSummaryComponent implements OnInit {
  jobTracks: JobTrack[];
  constructor() { }

  ngOnInit(): void {
  }

}
