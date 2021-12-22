import { Joborder } from '../../models/joborder';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-joblist',
  templateUrl: './joblist.component.html',
  styleUrls: ['./joblist.component.css']
})

export class JoblistComponent implements OnInit {
  @Input() job: Joborder;
  constructor() {
   }

  ngOnInit(): void {
  }

}
