import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';

import { DialogService } from '../../core/dialog.service';
import { Color } from '../color.model';
import { ColorService } from '../color.service';
import { Department } from '../department.model';
import { DepartmentService } from '../department.service';
import { Employee } from '../employee.model';
import { EmployeeService } from '../employee.service';
import { PermissionByEmployeeListComponent } from '../permission-by-employee-list/permission-by-employee-list.component';
import { enumPosition, Position } from '../position.model';
import { PositionService } from '../position.service';
import { Shift } from '../shift.model';
import { ShiftService } from '../shift.service';
import { enumStatus, Status } from '../status.model';
import { StatusService } from '../status.service';


@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {

  public form: FormGroup;
  public errorMessage: string;

  searchResultManagers: Employee[];
  searchResultPositions: Position[];
  searchResultDepartments: Department[];
  searchResultShifts: Shift[];
  searchResultFavoriteColors: Color[];
  searchResultStatuses: Status[];


  constructor(private fb: FormBuilder,
              private serviceData: EmployeeService,
              private positionService: PositionService,
              private departmentService: DepartmentService,
              private shiftService: ShiftService,
              private favoriteColorService: ColorService,
              private statusService: StatusService,
              private dialogService: DialogService,
              private dialog: MatDialog,
              private activatedRoute: ActivatedRoute,
              private route: Router) {

    this.errorMessage = '';
  }


  ngOnInit() {

    this.form = this.fb.group({
      EmployeeID: [null, [Validators.required]],
      Name: [null, [Validators.required, Validators.maxLength(128)]],
      StartDate: [null, [Validators.required]],
      EndDate: [null],
      ManagerID: [null],
      PositionID: [null, [Validators.required, Validators.min(1)]],
      DepartmentID: [null, [Validators.required, Validators.min(1)]],
      ShiftID: [null, [Validators.required, Validators.min(1)]],
      FavoriteColorID: [null, [Validators.required, Validators.min(1)]],
      StatusID: [null, [Validators.required, Validators.min(1)]],
      PreferredPhoneID: [null],
      TeamMemberPhoto: [null],
    });

    this.positionService.getAll('Name', 'asc', null)
      .pipe(
        tap((items) => this.searchResultPositions = items))
      .subscribe();

    this.departmentService.getAll('Name', 'asc', null)
      .pipe(
        tap((items) => this.searchResultDepartments = items))
      .subscribe();

    this.shiftService.getAll('Name', 'asc', null)
      .pipe(
        tap((items) => this.searchResultShifts = items))
      .subscribe();

    //Managers
    this.serviceData.getAll('Name', 'asc', null)
      .pipe(
        map((managers) => managers.filter(x => x.Position.PositionID === enumPosition.Manager)),
        tap((items) => this.searchResultManagers = items))
      .subscribe();

    this.favoriteColorService.getAll('Name', 'asc', null)
      .pipe(
        tap((items) => this.searchResultFavoriteColors = items))
      .subscribe()

    this.statusService.getAll('Name', 'asc', null)
      .pipe(
        tap((items) => this.searchResultStatuses = items))
      .subscribe();
    
    this.activatedRoute.paramMap
      .subscribe(params => {
        if (+params.get('id') > 0) {
          this.getItem(+params.get('id'));
        }
        else {
          this.initialize();
        }
      });
  }

  getItem(itemID: number): void {

    this.serviceData.getItem(itemID)
      .pipe(
        tap((item) => this.displayItem(item)),
        tap((item) => this.filterManager()))
      .subscribe(
        null,
        (error) => this.errorMessage = error);
  }

  submit(): void {

    if (this.form.valid) {
      if (this.form.dirty) {

        let newItem: Employee = this.form.value;

        if (newItem.EmployeeID === 0) {
          this.serviceData.insert(newItem)
            .subscribe(
              (item: Employee) => {
                this.form.get('EmployeeID').setValue(item.EmployeeID);
                this.onSubmitComplete();
              },
              (error: any) => {

                this.errorMessage = <any>
                  error;
              }
            );
        } else {
          this.serviceData.update(newItem.EmployeeID, newItem)
            .subscribe(
              () => {
                this.onSubmitComplete();
              },
              (error: any) => {
                this.errorMessage = <any>
                  error;
              }
            );
        }
      } else {
        this.errorMessage = 'Please make some changes.';
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
  }

  newItem() {
    this.initialize();
  }

  initialize() {
    this.form.patchValue({
      EmployeeID: 0,
      Name: null
    });
  }

  openDeleteDialog(): void {
    this.dialogService.confirm('Do you really want to delete this employee')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('EmployeeID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/employees']));
  }

  openMarkAsTerminantedDialog(): void {
    this.dialogService.confirm('Do you really want to mark employee as terminated')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            this.form.get('StatusID').setValue(enumStatus.Terminated);
            this.form.get('EndDate').setValue(new Date());
            return this.serviceData.update(+this.form.get('EmployeeID').value, this.form.value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/employees']));
  }

  onSubmitComplete(): void {
    this.form.markAsUntouched();
    this.form.markAsPristine();
  }

  displayItem(item: Employee): void {

    if (this.form) {
      this.form.reset();
    }

    this.form.patchValue({
      ...item
    });
  }

  filterManager() {
    if (this.searchResultManagers) {
      this.searchResultManagers = this.searchResultManagers.filter(x => x.EmployeeID !== this.form.get('EmployeeID').value);
    }
  }

  onPhoneChanged(phoneID: number) {
    this.form.get('PreferredPhoneID').setValue(phoneID);
  }

  viewPermissions(employeeID: number) {
    this.dialog.open(PermissionByEmployeeListComponent, {
      width: '600px',
      height: '600px',
      data: { employeeID: employeeID }
    });    
  }
}
