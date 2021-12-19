import { JoborderResource } from './../../models/JoborderResource';
import { ApiResult } from './../../_services/base.service';
import { UsersService } from './../../_services/user.service';
import { User } from './../../models/user';
import { JobOrderService } from './../../_services/job-order.service';
import { Component, Inject, OnInit } from '@angular/core';
import { BaseFormComponent } from 'src/app/models/base.form.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-detil-laporan',
  templateUrl: './detil-laporan.component.html',
  styleUrls: ['./detil-laporan.component.css']
})
export class DetilLaporanComponent extends BaseFormComponent implements OnInit {
  //the view title
  title: string;

  //form model
  override form: FormGroup;
  //letter object to edit or create
  jobOrder: JoborderResource;
   // the letter object id, as fetched from the active route:
  // It's NULL when we're adding a new letter,
  // and not NULL when we're editing an existing one.
  id?: number;
  listKoordinator: User[];
  today = new Date();

  constructor(private router: Router,
              private usersService: UsersService,
              private jobOrderService: JobOrderService,
              private dialogRef: MatDialogRef<DetilLaporanComponent>,
              @Inject(MAT_DIALOG_DATA) data) {
                      super();
                      this.id = data.id;
     }

     ngOnInit() {
      this.form = new FormGroup({
        namaKlien: new FormControl('', Validators.required),
        nomorSurat: new FormControl('', Validators.required),
        tanggalSurat: new FormControl([formatDate(this.today.getDate(), 'dd-mm-yyyy', 'en')], Validators.required),
        idKoordinator: new FormControl('', Validators.required),
        notes: new FormControl(),
      }, null, null);
  
      this.loadData();
    }
  
  loadData() {
    //load daftar user
    this.usersService.getData<ApiResult<User>>(
      0, 100,
      "namaDepan", null,
      null, null)
      .subscribe(result => {
        this.listKoordinator = result.data;
      }, error => console.error(error));
      //get id from parameter 'id'
      if (this.id) {
        //edit mode
        //fetch data from server
        this.jobOrderService.get<JoborderResource>(this.id).subscribe(result => {
          this.jobOrder = result as JoborderResource;
  
          this.title = "Edit - " + this.jobOrder.namaKlien + this.jobOrder.nomorSurat;
  
          //update form with letter value
          this.form.patchValue(this.jobOrder);
        }, error => console.error(error));
      } else {
        //ADD NEW Mode
        this.title = "Input Surat Perintah";
      }
      
    }
  
    onSubmit() {
      var jo = (this.id) ? this.jobOrder : <JoborderResource>{};
  
      jo.namaKlien = this.form.get('namaKlien').value;
      jo.nomorSurat = this.form.get('nomorSurat').value;
      jo.tanggalSurat = this.form.get('tanggalSurat').value;
      jo.idKoordinator = this.form.get('idKoordinator').value;
      jo.notes = this.form.get('notes').value;
      
      if (this.id) {
        //EDIT MODE
        this.jobOrderService
          .put<JoborderResource>(jo)
          .subscribe(result => {
            console.log("Surat " + jo.nomorSurat + " Sudah diupdate");
            //go back to letters view
          }, error => console.error(error));
      } else {
        //ADD NEW MODE
        this.jobOrderService
          .post<JoborderResource>(jo)
          .subscribe(result => {
            console.log("Surat " + result.nomorSurat + " berhasil dibuat.");
            //back to letters view
          }, error => console.error(error));
      }
      this.dialogRef.close();
    }
}

