import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

import { Color } from '../color.model';
import { ColorService } from '../color.service';

@Component({
  selector: 'app-color-list',
  templateUrl: './color-list.component.html',
  styleUrls: ['./color-list.component.css']
})
export class ColorListComponent implements AfterViewInit, OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  //@ViewChild(MatTable, { static: false }) table: MatTable<Color>;

  filterControl = new FormControl();

  public dataSource: Color[] = new Array<Color>();

  displayedColumns = [
    'ColorID',
    'Name',
    'Command1'    
  ];

  constructor(private dataService: ColorService) {

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
