import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { EMPTY, of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { DialogService } from '../../core/dialog.service';

import { Shift } from '../shift.model';
import { ShiftService } from '../shift.service';

@Component({
  selector: 'app-shift-edit',
  templateUrl: './shift-edit.component.html',
  styleUrls: ['./shift-edit.component.css']
})
export class ShiftEditComponent implements OnInit {

  public form: FormGroup;
  public errorMessage: string;

  constructor(private fb: FormBuilder,
    private serviceData: ShiftService,
    private dialogService: DialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private route: Router,
  ) {

    this.errorMessage = '';
  }


  ngOnInit() {
    this.form = this.fb.group({
      ShiftID: [null, [Validators.required]],
      Name: [null, [Validators.required, Validators.maxLength(128)]]
    });

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
        tap((item) => this.displayItem(item)))
      .subscribe(
        null,
        (error) => this.errorMessage = error);
  }

  submit(): void {

    if (this.form.valid) {
      if (this.form.dirty) {

        let newItem: Shift = this.form.value;

        if (newItem.ShiftID === 0) {
          this.serviceData.insert(newItem)
            .subscribe(
              (item: Shift) => {
                this.form.get('ShiftID').setValue(item.ShiftID);
                this.onSubmitComplete();

              },
              (error: any) => {

                this.errorMessage = <any>
                  error;
              }
            );
        } else {
          this.serviceData.update(newItem.ShiftID, newItem)
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
      ShiftID: 0,
      Name: null
    });
  }

  openDeleteDialog(): void {

    this.dialogService.confirm('Do you really want to delete this shift')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('ShiftID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/shifts']));
  }

  deleteItem(itemID: number) {

    if (itemID > 0) {
      this.serviceData.delete(itemID)
        .subscribe(
          (item: Shift) => {
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

  displayItem(item: Shift): void {

    if (this.form) {
      this.form.reset();
    }

    this.form.patchValue({
      ShiftID: item.ShiftID,
      Name: item.Name ? item.Name : null
    });
  }


}
