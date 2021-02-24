import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Department } from './department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService implements BaseService<Department> {

  baseUrl: string = `${environment.baseAPIUrl}api/Departments`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Department[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<Department[]>(url);
  }

  getItem(id: number): Observable<Department> {
    return this.http.get<Department>(`${this.baseUrl}/${id}`);
  }

  insert(department: Department): Observable<Department> {
    return this.http.post<Department>(`${this.baseUrl}`, department);
  }

  update(id: number, department: Department) {
    return this.http.put<Department>(`${this.baseUrl}/${id}`, department);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
