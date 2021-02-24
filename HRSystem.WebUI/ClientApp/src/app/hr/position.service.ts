import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Position } from './position.model';

@Injectable({
  providedIn: 'root'
})
export class PositionService implements BaseService<Position> {

  baseUrl: string = `${environment.baseAPIUrl}api/Positions`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Position[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<Position[]>(url);
  }

  getItem(id: number): Observable<Position> {
    return this.http.get<Position>(`${this.baseUrl}/${id}`);
  }

  insert(position: Position): Observable<Position> {
    return this.http.post<Position>(`${this.baseUrl}`, position);
  }

  update(id: number, position: Position) {
    return this.http.put<Position>(`${this.baseUrl}/${id}`, position);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
