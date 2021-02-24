import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Status } from './status.model';

@Injectable({
  providedIn: 'root'
})
export class StatusService implements BaseService<Status> {

  baseUrl: string = `${environment.baseAPIUrl}api/Statuses`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Status[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<Status[]>(url);
  }

  getItem(id: number): Observable<Status> {
    return this.http.get<Status>(`${this.baseUrl}/${id}`);
  }

  insert(status: Status): Observable<Status> {
    return this.http.post<Status>(`${this.baseUrl}`, status);
  }

  update(id: number, status: Status) {
    return this.http.put<Status>(`${this.baseUrl}/${id}`, status);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
