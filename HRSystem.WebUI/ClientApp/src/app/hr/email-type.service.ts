import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { EmailType } from './email-type.model';

@Injectable({
  providedIn: 'root'
})
export class EmailTypeService implements BaseService<EmailType> {

  baseUrl: string = `${environment.baseAPIUrl}api/EmailTypes`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<EmailType[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<EmailType[]>(url);
  }

  getItem(id: number): Observable<EmailType> {
    return this.http.get<EmailType>(`${this.baseUrl}/${id}`);
  }

  insert(emailType: EmailType): Observable<EmailType> {
    return this.http.post<EmailType>(`${this.baseUrl}`, emailType);
  }

  update(id: number, emailType: EmailType) {
    return this.http.put<EmailType>(`${this.baseUrl}/${id}`, emailType);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
