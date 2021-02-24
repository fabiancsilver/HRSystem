import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

import { Employee } from '../employee.model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements AfterViewInit, OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  //@ViewChild(MatTable, { static: false }) table: MatTable<Employee>;

  filterControl = new FormControl();

  public dataSource: Employee[] = new Array<Employee>();

  displayedColumns = [
    'EmployeeID',
    'Name',
    'StartDate',
    'EndDate',
    'Position',
    'Department',
    'Shift',
    'Manager',
    'Color',
    'Status',
    'Command1'
  ];

  constructor(private dataService: EmployeeService) {

  }

  ngOnInit() {

    merge(this.sort.sortChange, this.filterControl.valueChanges)
      .pipe(
        startWith(this.sort),
        switchMap((sort) => this.getData$(this.sort.active, this.sort.direction, this.filterControl.value)))
      .subscribe(
        (result) => this.dataSource = result);

  }

  getData$(sortBy: string, direction: string, filterBy: string) {
    return this.dataService.getAll(sortBy, direction, filterBy);
  }

  ngAfterViewInit() {
    //this.dataSource.sort = this.sort;
    //this.dataSource.paginator = this.paginator;
    //this.table.dataSource = this.dataSource;
  }

  openEditDialog() {

  }

  openDeleteDialog() {

  }
}
