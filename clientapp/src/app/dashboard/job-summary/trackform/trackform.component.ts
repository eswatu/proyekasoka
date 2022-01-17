import { JobtrackService } from './../../../_services/jobtrack.service';
import { JobTrack } from './../../../models/jobTrack';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BaseFormComponent } from 'src/app/models/base.form.component';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-trackform',
  templateUrl: './trackform.component.html',
  styleUrls: ['./trackform.component.css']
})
export class TrackformComponent extends BaseFormComponent implements OnInit {
  public orderId: number;
  jobTrack: JobTrack;

  override form: FormGroup;
  
  constructor(private jobtrackService: JobtrackService,
    private dialogRef: MatDialogRef<TrackformComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
          super();
          this.orderId = data.id;
       }

  ngOnInit(): void {
    this.form = new FormGroup({
      laporan: new FormControl('', Validators.required),
      nominal: new FormControl('',Validators.required)
    }, null, null); 
  }

  onSubmit() { 
    var entry = <JobTrack>{};

    entry.laporan = this.form.get('laporan').value;
    entry.nominal = this.form.get('nominal').value;
    entry.idJobOrder = this.orderId;
    this.jobtrackService.post<JobTrack>(entry)
      .subscribe(result => {
        console.log("Berhasil masuk");

      }, error => console.error(error));
    this.dialogRef.close();
  }
}
