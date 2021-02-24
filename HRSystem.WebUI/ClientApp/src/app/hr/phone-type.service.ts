import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { PhoneType } from './phone-type.model';

@Injectable({
  providedIn: 'root'
})
export class PhoneTypeService implements BaseService<PhoneType> {

  baseUrl: string = `${environment.baseAPIUrl}api/PhoneTypes`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<PhoneType[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<PhoneType[]>(url);
  }

  getItem(id: number): Observable<PhoneType> {
    return this.http.get<PhoneType>(`${this.baseUrl}/${id}`);
  }

  insert(phoneType: PhoneType): Observable<PhoneType> {
    return this.http.post<PhoneType>(`${this.baseUrl}`, phoneType);
  }

  update(id: number, phoneType: PhoneType) {
    return this.http.put<PhoneType>(`${this.baseUrl}/${id}`, phoneType);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
