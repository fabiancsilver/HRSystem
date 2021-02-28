import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  
  baseApiUrl = environment.baseAPIUrl +'api/Employees';

  constructor(private http: HttpClient) {

  }
  
  upload(employeeID: number, file): Observable<any> {
    
    const formData = new FormData();    
    formData.append("file", file, file.name);

    return this.http.post(`${this.baseApiUrl}/UploadPhoto/${employeeID}`, formData)
  }
} 
