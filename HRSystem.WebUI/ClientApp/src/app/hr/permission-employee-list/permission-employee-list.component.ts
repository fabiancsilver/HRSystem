import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { tap } from 'rxjs/operators';
import { PermissionEmployee } from '../permission-employee.model';
import { PermissionService } from '../permission.service';

@Component({
  selector: 'app-permission-employee-list',
  templateUrl: './permission-employee-list.component.html',
  styleUrls: ['./permission-employee-list.component.css']
})
export class PermissionEmployeeListComponent implements OnInit {

  public dataSource: Array<PermissionEmployee> = [];
  public isLoading = true;
  public filterControl: FormControl = new FormControl('');

  public displayedColumns: string[] = [
    'Employee',
    'Permission'];

  constructor(private serviceData: PermissionService) {

  }

  ngOnInit(): void {
    this.serviceData
      .getAll()
      .pipe(
        tap(data => {
          this.dataSource = data;
        }))
      .subscribe();
  }
}
