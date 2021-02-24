import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

import { PhoneType } from '../phone-type.model';
import { PhoneTypeService } from '../phone-type.service';

@Component({
  selector: 'app-phone-type-list',
  templateUrl: './phone-type-list.component.html',
  styleUrls: ['./phone-type-list.component.css']
})
export class PhoneTypeListComponent implements AfterViewInit, OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  //@ViewChild(MatTable, { static: false }) table: MatTable<PhoneType>;

  filterControl = new FormControl();

  public dataSource: PhoneType[] = new Array<PhoneType>();

  displayedColumns = [
    'PhoneTypeID',
    'Name',
    'Command1'
  ];

  constructor(private dataService: PhoneTypeService) {

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
