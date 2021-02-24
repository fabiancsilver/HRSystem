import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

import { AddressType } from '../address-type.model';
import { AddressTypeService } from '../address-type.service';

@Component({
  selector: 'app-address-type-list',
  templateUrl: './address-type-list.component.html',
  styleUrls: ['./address-type-list.component.css']
})
export class AddressTypeListComponent implements AfterViewInit, OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  //@ViewChild(MatTable, { static: false }) table: MatTable<AddressType>;

  filterControl = new FormControl();

  public dataSource: AddressType[] = new Array<AddressType>();

  displayedColumns = [
    'AddressTypeID',
    'Name',
    'Command1'   
  ];

  constructor(private dataService: AddressTypeService) {

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
