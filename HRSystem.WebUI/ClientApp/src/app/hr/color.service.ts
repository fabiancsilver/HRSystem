import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Color } from './color.model';

@Injectable({
  providedIn: 'root'
})
export class ColorService implements BaseService<Color> {

  baseUrl: string = `${environment.baseAPIUrl}api/Colors`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Color[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<Color[]>(url);
  }

  getItem(id: number): Observable<Color> {
    return this.http.get<Color>(`${this.baseUrl}/${id}`);
  }

  insert(color: Color): Observable<Color> {
    return this.http.post<Color>(`${this.baseUrl}`, color);
  }

  update(id: number, color: Color) {
    return this.http.put<Color>(`${this.baseUrl}/${id}`, color);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
