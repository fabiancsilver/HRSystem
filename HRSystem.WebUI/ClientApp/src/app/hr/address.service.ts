import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

import { BaseService } from './base.service';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService implements BaseService<Address> {

  baseUrl: string = `${environment.baseAPIUrl}api/Addresses`;

  constructor(private http: HttpClient) {

  }

  getAll(): Observable<Address[]> {
    return this.http.get<Address[]>(this.baseUrl);
  }

  getItem(id: number): Observable<Address> {
    return this.http.get<Address>(`${this.baseUrl}/${id}`);
  }

  getByEmployee(employeeID: number): Observable<Address> {
    return this.http.get<Address>(`${this.baseUrl}/ByEmployee/${employeeID}`);
  }

  insert(address: Address): Observable<Address> {
    return this.http.post<Address>(`${this.baseUrl}`, address);
  }

  update(id: number, address: Address) {
    return this.http.put<Address>(`${this.baseUrl}/${id}`, address);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
