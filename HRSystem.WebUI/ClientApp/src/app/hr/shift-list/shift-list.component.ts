import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

import { Shift } from '../shift.model';
import { ShiftService } from '../shift.service';

@Component({
  selector: 'app-shift-list',
  templateUrl: './shift-list.component.html',
  styleUrls: ['./shift-list.component.css']
})
export class ShiftListComponent implements AfterViewInit, OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  //@ViewChild(MatTable, { static: false }) table: MatTable<Shift>;

  filterControl = new FormControl();

  public dataSource: Shift[] = new Array<Shift>();

  displayedColumns = [
    'ShiftID',
    'Name',
    'Command1'
  ];

  constructor(private dataService: ShiftService) {

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
