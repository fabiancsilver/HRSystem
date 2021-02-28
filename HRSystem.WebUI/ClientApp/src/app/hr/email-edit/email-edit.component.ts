import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { from, of } from 'rxjs';
import { concatMap, switchMap, tap } from 'rxjs/operators';

import { DialogService } from '../../core/dialog.service';
import { EmailType } from '../email-type.model';
import { EmailTypeService } from '../email-type.service';
import { Email } from '../email.model';
import { EmailService } from '../email.service';

@Component({
  selector: 'app-email-edit',
  templateUrl: './email-edit.component.html',
  styleUrls: ['./email-edit.component.css']
})
export class EmailEditComponent implements OnInit, OnChanges {

  public form: FormGroup;
  public errorMessage: string;
  searchResultEmailTypes: EmailType[];


  get emails(): FormArray {
    return this.form.get('Emails') ? <FormArray>this.form.get('Emails') : new FormArray([]);
  }

  @Input('EmployeeID') employeeID: number;


  constructor(private fb: FormBuilder,
    private serviceData: EmailService,
    private emailTypeService: EmailTypeService,
    private dialogService: DialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private route: Router) {

    this.errorMessage = '';
  }



  ngOnInit() {
    this.form = this.fb.group({
      Emails: this.fb.array([])
    });

    this.emailTypeService.getAll('Name', 'asc', null)
      .pipe(
        tap((items) => this.searchResultEmailTypes = items))
      .subscribe();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes) {
      this.serviceData.getAllByEmployee(this.employeeID)
        .pipe(
          tap((emails) => {
            if (emails) {
              this.displayItem(emails);
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

  submit(): void {

    if (this.form.valid) {
      if (this.form.dirty) {


        from(this.emails.controls)
          .pipe(
            concatMap((email) => {
              if (email.value.EmailID === 0) {
                return this.serviceData.insert(email.value);
              }
              else {
                return this.serviceData.update(email.value.EmailID, email.value);
              }
            }))
          .subscribe(
            () => this.onSubmitComplete()
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
      EmailID: 0,
      EmployeeID: this.employeeID,
      EmailTypeID: 0,
      EmailAddress: null
    });
    this.emails.push(formControl);
  }

  initialize() {
    let formControl = this.buildFormGroup();
    formControl.patchValue({
      EmailID: 0,
      EmployeeID: this.employeeID,
      EmailTypeID: 0,
      EmailAddress: null
    });
    this.emails.push(formControl);
  }

  openDeleteDialog(): void {

    this.dialogService.confirm('Do you really want to delete this email')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('EmailID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/emails']));
  }

  deleteItem(itemID: number) {

    if (itemID > 0) {
      this.serviceData.delete(itemID)
        .subscribe(
          (item: Email) => {
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

  displayItem(emails: Email[]): void {

    if (this.form) {
      this.form.reset();
    }

    if (emails && emails.length > 0) {
      emails.forEach((email) => {
        let formGroup = this.buildFormGroup();
        formGroup.patchValue({
          ...email
        });
        this.emails.push(formGroup);
      });
    }
  }

  buildFormGroup(): FormGroup {
    return this.fb.group({
      EmailID: [null, [Validators.required]],
      EmployeeID: [null, [Validators.required, Validators.min(1)]],
      EmailTypeID: [null, [Validators.required, Validators.min(1)]],
      EmailAddress: [null, [Validators.required, Validators.maxLength(128)]]
    });
  }
}
