import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Employee } from './employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService implements BaseService<Employee> {

  baseUrl: string = `${environment.baseAPIUrl}api/Employees`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Employee[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}/?sortBy=${sortBy}&direction=${direction}&filterBy=${filterBy}`;

    return this.http.get<Employee[]>(url);
  }



  getItem(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.baseUrl}/${id}`);
  }

  insert(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this.baseUrl}`, employee);
  }

  update(id: number, employee: Employee) {
    return this.http.put<Employee>(`${this.baseUrl}/${id}`, employee);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
