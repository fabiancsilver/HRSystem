import { Component, EventEmitter, Inject, Input, OnChanges, OnDestroy, OnInit, Optional, Output, SimpleChanges } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { concat, EMPTY, from, of } from 'rxjs';
import { concatMap, map, switchMap, tap } from 'rxjs/operators';
import { DialogService } from '../../core/dialog.service';
import { EmployeeService } from '../employee.service';
import { PhoneType } from '../phone-type.model';
import { PhoneTypeService } from '../phone-type.service';

import { Phone } from '../phone.model';
import { PhoneService } from '../phone.service';

@Component({
  selector: 'app-phone-edit',
  templateUrl: './phone-edit.component.html',
  styleUrls: ['./phone-edit.component.css']
})
export class PhoneEditComponent implements OnInit, OnChanges, OnDestroy {

  public form: FormGroup;
  public errorMessage: string;
  searchResultPhoneTypes: PhoneType[];

  get phones(): FormArray {
    return this.form.get('Phones') ? <FormArray> this.form.get('Phones') : new FormArray([]);
  }

  @Input('EmployeeID') employeeID: number;
  @Input('PreferredPhoneID') preferredPhoneID: number = 0;
  @Output('PhoneChanged') phoneChanged = new EventEmitter<number>();

  constructor(private fb: FormBuilder,
              private serviceData: PhoneService,
              private phoneTypeService: PhoneTypeService,
              private dialogService: DialogService,
              private employeeService: EmployeeService,
              private dialog: MatDialog,
              private activatedRoute: ActivatedRoute,
              private route: Router,
  ) {

    this.errorMessage = '';
  }

  ngOnInit() {
    this.form = this.fb.group({
        Phones: this.fb.array([])
      });    

    this.phoneTypeService.getAll('Name','asc', null)
      .pipe(
        tap((items) => this.searchResultPhoneTypes = items))
      .subscribe();   
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes) {
      this.serviceData.getAllByEmployee(this.employeeID)
        .pipe(
          tap((phones) => {
            if (phones) {
              this.displayItem(phones);
            }
            else {
              this.initialize();
            }
          }))
        .subscribe(
          null,
          (error) => this.errorMessage = error);
    }
  }

  ngOnDestroy(): void {
    if (this.preferredPhoneID) {
      this.phoneChanged.emit(this.preferredPhoneID)
    }    
  }

  submit(): void {

    if (this.form.valid) {
      if (this.form.dirty) {
        from(this.phones.controls)
          .pipe(
            concatMap((phone) => {
              if (phone.value.PhoneID === 0 ) {
                return this.serviceData.insert(phone.value)
                  .pipe(
                    tap(result => {
                      phone.get('PhoneID').setValue(result.PhoneID)
                    })
                  );
              }
              else {
                return this.serviceData.update(phone.value.PhoneID, phone.value);
              }
            }))
          .subscribe(
            ()=> this.onSubmitComplete()
          );
      } else {
        this.errorMessage = 'Please make some changes.';
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
  }

  newItem() {
    let formControl = this.buildFormGroup();

    formControl.patchValue({
      PhoneID: 0,
      EmployeeID: this.employeeID,
      PhoneTypeID: 0,
      PhoneNumber: null
    });
    this.phones.push(formControl);   
  }

  initialize() {
    let formControl = this.buildFormGroup();
    formControl.patchValue({
      PhoneID: 0,
      EmployeeID: this.employeeID,
      PhoneTypeID: 0,
      PhoneNumber: null
    });
    this.phones.push(formControl);
  }

  openDeleteDialog(): void {

    this.dialogService.confirm('Do you really want to delete this phone')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('PhoneID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/phones']));
  }

  deleteItem(itemID: number) {

    if (itemID > 0) {
      this.serviceData.delete(itemID)
        .subscribe(
          (item: Phone) => {
          },
          (error: any) => {
            this.errorMessage = <any>error;
          }
        );
    }
    else {
      this.errorMessage = 'Error';
    }
  }

  onSubmitComplete(): void {
    this.form.markAsUntouched();
    this.form.markAsPristine();
  }

  displayItem(phones: Phone[]): void {

    if (this.form) {
      this.form.reset();
    }

    if (phones && phones.length > 0) {
      phones.forEach((phone) => {
        let formGroup = this.buildFormGroup();
        formGroup.patchValue({
          ...phone
        });
        this.phones.push(formGroup);
      });
    }    
  }

  buildFormGroup(): FormGroup {
    return this.fb.group({
      PhoneID: [null, [Validators.required]],
      EmployeeID: [null, [Validators.required, Validators.min(1)]],
      PhoneTypeID: [null, [Validators.required, Validators.min(1)]],
      PhoneNumber: [null, [Validators.required, Validators.maxLength(128)]]
    });
  }

  openMarkAsPreferredDialog(employeeID: number, phoneID: number): void {
    this.dialogService.confirm('Do you really want to mark as Preferred')
      .pipe(
        switchMap((result) => {
          return this.employeeService.getItem(employeeID);
        }),
        switchMap((employee) => {          
          this.preferredPhoneID = phoneID;
          employee.PreferredPhoneID = phoneID;
          return this.employeeService.update(employee.EmployeeID, employee);
        }))
      .subscribe();
  }
}
