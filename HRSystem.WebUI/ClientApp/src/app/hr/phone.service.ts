import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

import { BaseService } from './base.service';
import { Phone } from './phone.model';

@Injectable({
  providedIn: 'root'
})
export class PhoneService implements BaseService<Phone> {

  baseUrl: string = `${environment.baseAPIUrl}api/Phones`;

  constructor(private http: HttpClient) {

  }

  getAll(): Observable<Phone[]> {
    return this.http.get<Phone[]>(this.baseUrl);
  }

  getAllByEmployee(employeeID: number): Observable<Phone[]> {
    return this.http.get<Phone[]>(`${this.baseUrl}/AllByEmployee/${employeeID}`);
  }

  getItem(id: number): Observable<Phone> {
    return this.http.get<Phone>(`${this.baseUrl}/${id}`);
  }

  getByEmployee(employeeID: number): Observable<Phone> {
    return this.http.get<Phone>(`${this.baseUrl}/ByEmployee/${employeeID}`);
  }

  insert(phone: Phone): Observable<Phone> {
    return this.http.post<Phone>(`${this.baseUrl}`, phone);
  }

  update(id: number, phone: Phone) {
    return this.http.put<Phone>(`${this.baseUrl}/${id}`, phone);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
