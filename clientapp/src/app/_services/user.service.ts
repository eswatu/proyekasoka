import { User } from '../models/user';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService extends BaseService{

  url;

  getData<ApiResult>(
    pageIndex: number, pageSize: number,
    sortColumn: string, sortOrder: string,
    filterColumn: string, filterQuery: string): Observable<ApiResult> {
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

  get<User>(id: number): Observable<User> {
    let urlid = this.url + id;
    return this.http.get<User>(urlid);
  }
  put<User>(item): Observable<User> {
    let urlid = this.url + item.id;
    return this.http.put<User>(urlid, item);
  }

  post<User>(item: User): Observable<User> {
    return this.http.post<User>(this.url, item);
  }

  constructor(http: HttpClient) {
    super(http);
    this.url = this.api_url + "/api/Users/";
  }
  getAll() {
    return this.http.get<User[]>(this.url);
}
}