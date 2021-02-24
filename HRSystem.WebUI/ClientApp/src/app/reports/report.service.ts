import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

import { TerminatedNumber } from './terminated-number.model';
import { WeeklyHireNumber } from './weekly-hire-number.model';
import { NumberOfEmployeeDepartment } from './number-of-employee-department.model';
import { NumberOfEmployeeManager } from './number-of-employee-manager.model';
import { RetentionRate } from './retention-rate.model';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private baseUrl: string = `${environment.baseAPIUrl}api/Reports`;

  constructor(private http: HttpClient) {

  }

  getRetentionRate(): Observable<RetentionRate> {
    return this.http.get<RetentionRate>(`${this.baseUrl}/RetentionRate`);
  }

  getWeeklyHireNumbers(): Observable<WeeklyHireNumber[]> {
    return this.http.get<WeeklyHireNumber[]>(`${this.baseUrl}/WeeklyHireNumbers`);
  }

  getTerminatedNumbers(): Observable<TerminatedNumber[]> {
    return this.http.get<TerminatedNumber[]>(`${this.baseUrl}/TerminatedNumbers`);
  }

  getNumberOfEmployeeDepartments(): Observable<NumberOfEmployeeDepartment[]> {
    return this.http.get<NumberOfEmployeeDepartment[]>(`${this.baseUrl}/NumberOfEmployeeDepartments`);
  }

  getNumberOfEmployeeManagers(): Observable<NumberOfEmployeeManager[]> {
    return this.http.get<NumberOfEmployeeManager[]>(`${this.baseUrl}/NumberOfEmployeeManagers`);
  }

}
