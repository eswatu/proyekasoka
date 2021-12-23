import { JobTrack } from './../models/jobTrack';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { BaseService } from '.';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class JobtrackService extends BaseService{
  constructor(http: HttpClient) {
    super(http);
    this.url = this.api_url + "/api/JobTrack";
  }
//base url
  url;

  getData<JobTrack>(orderId: number): Observable<JobTrack> {
    var refers = this.url + '/forOrderId/';
    var params = new HttpParams()
      .set("orderId", orderId);
    return this.http.get<JobTrack>(refers, { params });
    }

  get<JobTrack>(id: number): Observable<JobTrack> {
    let urlid = this.url + '/'+ id;
    return this.http.get<JobTrack>(urlid);
  }
  put<JobTrack>(item): Observable<JobTrack> {
    let urlid = this.url + '/'+ item.id;
    return this.http.put<JobTrack>(urlid, item);
  }
  post<JobTrack>(item: JobTrack): Observable<JobTrack> {
    let urlid = this.url + '/';
    return this.http.post<JobTrack>(urlid, item);
  }
}
