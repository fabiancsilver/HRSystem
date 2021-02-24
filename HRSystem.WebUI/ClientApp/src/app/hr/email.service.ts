import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

import { BaseService } from './base.service';
import { Email } from './email.model';

@Injectable({
  providedIn: 'root'
})
export class EmailService implements BaseService<Email> {

  baseUrl: string = `${environment.baseAPIUrl}api/Emails`;

  constructor(private http: HttpClient) {

  }

  getAll(): Observable<Email[]> {
    return this.http.get<Email[]>(this.baseUrl);
  }

  getAllByEmployee(employeeID: number): Observable<Email[]> {
    return this.http.get<Email[]>(`${this.baseUrl}/AllByEmployee/${employeeID}`);
  }

  getItem(id: number): Observable<Email> {
    return this.http.get<Email>(`${this.baseUrl}/${id}`);
  }

  insert(email: Email): Observable<Email> {
    return this.http.post<Email>(`${this.baseUrl}`, email);
  }

  update(id: number, email: Email) {
    return this.http.put<Email>(`${this.baseUrl}/${id}`, email);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
