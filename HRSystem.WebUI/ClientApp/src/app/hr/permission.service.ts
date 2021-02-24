import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { PermissionEmployee } from './permission-employee.model';


@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  basePermissionEmployeeUrl: string = `${environment.baseAPIUrl}api/PermissionEmployee`;

  constructor(private http: HttpClient) {

  }

  getAll(): Observable<PermissionEmployee[]> {
    let url: string = `${this.basePermissionEmployeeUrl}/`;

    return this.http.get<PermissionEmployee[]>(url);
  }

  getByEmployee(employeeID: number): Observable<PermissionEmployee[]> {

    let url: string = `${this.basePermissionEmployeeUrl}/ByEmployee/${employeeID}`;

    return this.http.get<PermissionEmployee[]>(url);
  }
 
}
