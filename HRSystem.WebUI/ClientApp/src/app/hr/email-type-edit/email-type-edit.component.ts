import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { EMPTY, of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { DialogService } from '../../core/dialog.service';

import { EmailType } from '../email-type.model';
import { EmailTypeService } from '../email-type.service';

@Component({
  selector: 'app-email-type-edit',
  templateUrl: './email-type-edit.component.html',
  styleUrls: ['./email-type-edit.component.css']
})
export class EmailTypeEditComponent implements OnInit {

  public form: FormGroup;
  public errorMessage: string;

  constructor(private fb: FormBuilder,
    private serviceData: EmailTypeService,
    private dialogService: DialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private route: Router,
  ) {

    this.errorMessage = '';
  }


  ngOnInit() {
    this.form = this.fb.group({
      EmailTypeID: [null, [Validators.required]],
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

        let newItem: EmailType = this.form.value;

        if (newItem.EmailTypeID === 0) {
          this.serviceData.insert(newItem)
            .subscribe(
              (item: EmailType) => {
                this.form.get('EmailTypeID').setValue(item.EmailTypeID);
                this.onSubmitComplete();

              },
              (error: any) => {

                this.errorMessage = <any>
                  error;
              }
            );
        } else {
          this.serviceData.update(newItem.EmailTypeID, newItem)
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
      EmailTypeID: 0,
      Name: null
    });
  }

  openDeleteDialog(): void {

    this.dialogService.confirm('Do you really want to delete this emailType')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('EmailTypeID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/emailTypes']));
  }

  deleteItem(itemID: number) {

    if (itemID > 0) {
      this.serviceData.delete(itemID)
        .subscribe(
          (item: EmailType) => {
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

  displayItem(item: EmailType): void {

    if (this.form) {
      this.form.reset();
    }

    this.form.patchValue({
      EmailTypeID: item.EmailTypeID,
      Name: item.Name ? item.Name : null
    });
  }


}
