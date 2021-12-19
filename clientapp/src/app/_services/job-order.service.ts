import { JoborderResource } from './../models/JoborderResource';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class JobOrderService extends BaseService{
  constructor(http: HttpClient) {
    super(http);
    this.url = this.api_url + "/api/Jobs";
  }
//base url
  url;

  getData<ApiResult>(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string,
    filterQuery: string
): Observable<ApiResult> {
    var params = new HttpParams()
        .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
        .set("sortColumn", sortColumn)
        .set("sortOrder", sortOrder);

    if (filterQuery) {
        params = params
            .set("filterColumn", filterColumn)
            .set("filterQuery", filterQuery);
    }

    return this.http.get<ApiResult>(this.url, { params });
}
  get<Joborder>(id: number): Observable<Joborder> {
    let urlid = this.url + '/'+ id;
    return this.http.get<Joborder>(urlid);
  }
  put<Joborder>(item): Observable<Joborder> {
    let urlid = this.url + item.id;
    return this.http.put<Joborder>(urlid, item);
  }
  post<JoborderResource>(item: JoborderResource): Observable<JoborderResource> {
    return this.http.post<JoborderResource>(this.url, item);
  }
}
