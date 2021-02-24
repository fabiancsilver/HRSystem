import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Shift } from './shift.model';

@Injectable({
  providedIn: 'root'
})
export class ShiftService implements BaseService<Shift> {

  baseUrl: string = `${environment.baseAPIUrl}api/Shifts`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Shift[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<Shift[]>(url);
  }

  getItem(id: number): Observable<Shift> {
    return this.http.get<Shift>(`${this.baseUrl}/${id}`);
  }

  insert(shift: Shift): Observable<Shift> {
    return this.http.post<Shift>(`${this.baseUrl}`, shift);
  }

  update(id: number, shift: Shift) {
    return this.http.put<Shift>(`${this.baseUrl}/${id}`, shift);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
