import { environment} from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

export abstract class BaseService {
    constructor(protected http: HttpClient) { }
    protected api_url = environment.apiUrl;

    abstract getData<ApiResult>(
        pageIndex: number,
        pageSize: number,
      sortColumn: string,
        sortOrder: string,
        filterColumn: string,
        filterQuery: string): Observable<ApiResult>;
    abstract get<T>(id: number): Observable<T>;
    abstract put<T>(item: T): Observable<T>;
    abstract post<T>(item: T): Observable<T>;
}

export interface ApiResult<T> {
    data: T[];
    pageIndex: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
    sortColumn: string;
    sortOrder: string;
    filterColumn: string;
    filterQuery: string;
}
export interface TimeBasedApi<T> {
  data: T[];
  pageIndex: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  fiterId: number;
  startDate: string; //ddmmyyyy
  endDate: string; //ddmmyyyy
  sortColumn: string;
  sortOrder: string;
  filterColumn: string;
  filterQuery: string;
}