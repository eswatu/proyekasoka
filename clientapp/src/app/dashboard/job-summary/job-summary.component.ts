import { Joborder } from './../../models/joborder';
import { JobOrderService } from './../../_services/job-order.service';
import { MatTableDataSource } from '@angular/material/table';
import { TrackformComponent } from './trackform/trackform.component';
import { ActivatedRoute } from '@angular/router';
import { ApiResult } from './../../_services/base.service';
import { JobtrackService } from './../../_services/jobtrack.service';
import { JobTrack } from './../../models/jobTrack';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
@Component({
  selector: 'app-job-summary',
  templateUrl: './job-summary.component.html',
  styleUrls: ['./job-summary.component.css']
})
export class JobSummaryComponent implements OnInit {
  orderId: number;
  jobTracks: MatTableDataSource<JobTrack>;
  constructor(private jobtrackService: JobtrackService,
    private jobOrderService: JobOrderService,
    private activatedRoute: ActivatedRoute,
    public dialog: MatDialog) { }
  displayedColumns = ['Nomor','nominal','laporan', 'trackTime']

  ngOnInit(): void {
    this.orderId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.loadSummary(this.orderId);
  }
  loadSummary(id: number) {
    this.jobtrackService.getData<JobTrack[]>(id)
      .subscribe(result => {
        this.jobTracks = new MatTableDataSource<JobTrack>(result);
        
      }, error => console.error(error));
  }
  konfirmasi() {
    this.jobOrderService.closeorder<Joborder>(this.orderId).subscribe(() => {
      //eksekusi kode
      this.loadSummary(this.orderId);
    }, error => console.error(error));
   }
  handleDismiss() { }


  tambahTrack() { 
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.restoreFocus; true;
    dialogConfig.minWidth = 400;
    dialogConfig.minHeight = 400;
    dialogConfig.data = { id:this.orderId };
    
 
    const dialogRef = this.dialog.open(TrackformComponent, dialogConfig)
    .afterClosed().pipe().subscribe(() => {
      this.loadSummary(this.orderId);
    });

  }
  calculation() {
    let sum: number = 0;
    if (this.jobTracks)
      for (let row of this.jobTracks.data) {
        if (row.id != 0) sum += row.nominal;
      }
    return sum;
  }
}
