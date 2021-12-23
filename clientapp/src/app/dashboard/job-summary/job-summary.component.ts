import { MatTableDataSource } from '@angular/material/table';
import { TrackformComponent } from './trackform/trackform.component';
import { ActivatedRoute } from '@angular/router';
import { ApiResult } from './../../_services/base.service';
import { JobtrackService } from './../../_services/jobtrack.service';
import { JobTrack } from './../../models/jobTrack';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DetilLaporanComponent } from 'src/app/laporan/detil-laporan/detil-laporan.component';

@Component({
  selector: 'app-job-summary',
  templateUrl: './job-summary.component.html',
  styleUrls: ['./job-summary.component.css']
})
export class JobSummaryComponent implements OnInit {
  orderId: number;
  public jobTracks: MatTableDataSource<JobTrack>;
  constructor(private jobtrackService: JobtrackService,
    private activatedRoute: ActivatedRoute,
    public dialog: MatDialog) { }
  displayedColumns = ['Nomor','nominal','laporan', 'trackTime']

  ngOnInit(): void {
    this.orderId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.loadSummary();
    console.log(this.jobTracks);
  }
  loadSummary() { 
    this.jobtrackService.getData<JobTrack[]>(this.orderId)
      .subscribe(result => {
        this.jobTracks = new MatTableDataSource<JobTrack>(result);
      }, error => console.error(error));
  }
  tambahTrack() { 
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.restoreFocus; true;
    dialogConfig.minWidth = 400;
    dialogConfig.minHeight = 400;
    dialogConfig.data = { id:this.orderId };
    
 
    const dialogRef = this.dialog.open(TrackformComponent, dialogConfig);
 
    dialogRef.afterClosed().subscribe(result => {
      this.jobTracks = null;
      this.loadSummary();
    });
  }
}
