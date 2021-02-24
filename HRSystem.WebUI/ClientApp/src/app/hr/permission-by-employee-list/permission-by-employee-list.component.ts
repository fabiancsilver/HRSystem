import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { merge, Observable, of } from 'rxjs';
import { catchError, startWith, switchMap, tap } from 'rxjs/operators';

import { PermissionEmployee } from '../permission-employee.model';
import { PermissionService } from '../permission.service';

@Component({
  selector: 'app-permission-by-employee-list',
  templateUrl: './permission-by-employee-list.component.html',
  styleUrls: ['./permission-by-employee-list.component.css']
})
export class PermissionByEmployeeListComponent implements OnInit { 

  public dataSource: Array<PermissionEmployee> = [];
  public isLoading = true;
  public filterControl: FormControl = new FormControl('');

  public displayedColumns: string[] = [
    'PermissionID',
    'Permission'];

  constructor(private serviceData: PermissionService,
              @Inject(MAT_DIALOG_DATA) private params: any) {

  }

  ngOnInit(): void {    
    this.serviceData
      .getByEmployee(+this.params.employeeID)
      .pipe(
        tap(data => {
          this.dataSource = data;
        }))
      .subscribe();
  }
}
