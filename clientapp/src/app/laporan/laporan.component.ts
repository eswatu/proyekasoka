import { FormControl } from '@angular/forms';
import { DetilLaporanComponent } from './detil-laporan/detil-laporan.component';
import { JobOrderService } from './../_services/job-order.service';
import { Joborder } from './../models/joborder';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Subject, debounceTime, distinctUntilChanged } from 'rxjs';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { SortDirection, MatSort } from '@angular/material/sort';
import { MatTableDataSource} from '@angular/material/table';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ApiResult } from '../_services/base.service';
import { MatTabChangeEvent } from '@angular/material/tabs';

@Component({
  selector: 'app-laporan',
  templateUrl: './laporan.component.html',
  styleUrls: ['./laporan.component.css']
})
export class LaporanComponent implements OnInit {

 //table
 public displayedColumns: string[] = ['index','namaKlien', 'nomorSurat', 'tanggalSurat', 'koordinator','notes','status'];
 public jobOrders: MatTableDataSource<Joborder>;
 defaultPageIndex: number = 0;
 defaultPageSize: number = 10;
 public defaultSortColumn: string = "namaKlien";
 public defaultSortOrder : SortDirection = "asc";
 defaultFilterColumn: string = "namaKlien";
 filterQuery: string = null;
 filterTextChanged: Subject<string> = new Subject<string>();
 @ViewChild(MatPaginator) paginator: MatPaginator;
 @ViewChild(MatSort) sort: MatSort;

 //query
  selectedType: number;
taskRange = new FormControl();
//formcontrol
startDate = new FormControl();
endDate = new FormControl();
//query string ddMMyyyy
sdte: string;
  edte: string;
  
 filterId = 0;
  filterRange = 30;
  filterStatus = new FormControl();

 constructor(private joborderService: JobOrderService, public dialog: MatDialog) {  }

 ngOnInit() {
   this.loadData(null);
 }

 openDialog(typeId:number) {
   const dialogConfig = new MatDialogConfig();
   dialogConfig.autoFocus = true;
   dialogConfig.restoreFocus; true;
   dialogConfig.minWidth = 400;
   dialogConfig.minHeight = 400;
   dialogConfig.data = { id: typeId};

   const dialogRef = this.dialog.open(DetilLaporanComponent, dialogConfig);

   dialogRef.afterClosed().subscribe(result => {
     this.jobOrders = null;
     this.loadData(null);
   });
 }
 onTabChanged(event: MatTabChangeEvent) {
  if (event.index == 1) {
    this.taskRange.setValue(null);

  }
}
onFilterTextChanged(filterText: string) {
 if (this.filterTextChanged.observers.length === 0) {
     this.filterTextChanged
         .pipe(debounceTime(1000), distinctUntilChanged())
       .subscribe(query => {
         this.jobOrders = null;
             this.loadData(query);
         });
 }
 this.filterTextChanged.next(filterText);
}

loadData(query: string = null) {
 var pageEvent = new PageEvent();
 pageEvent.pageIndex = this.defaultPageIndex;
 pageEvent.pageSize = this.defaultPageSize;
 if (query) {
     this.filterQuery = query;
 }
 this.getData(pageEvent);
}

getData(event: PageEvent) {

 var sortColumn = (this.sort)
   ? this.sort.active
   : this.defaultSortColumn;

 var sortOrder = (this.sort)
   ? this.sort.direction
   : this.defaultSortOrder;

 var filterColumn = (this.filterQuery)
   ? this.defaultFilterColumn
   : null;

 var filterQuery = (this.filterQuery)
   ? this.filterQuery
   : null;

 this.joborderService.getData<ApiResult<Joborder>>(
   event.pageIndex,
   event.pageSize,
   sortColumn,
   sortOrder,
   filterColumn,
   filterQuery)
   .subscribe(result => {
     this.paginator.length = result.totalCount;
     this.paginator.pageIndex = result.pageIndex;
     this.paginator.pageSize = result.pageSize;
     this.jobOrders = new MatTableDataSource<Joborder>(result.data);
   }, error => console.error(error));
}
}
