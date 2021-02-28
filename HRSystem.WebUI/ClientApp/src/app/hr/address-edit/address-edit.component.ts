import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { catchError, switchMap, tap } from 'rxjs/operators';

import { DialogService } from '../../core/dialog.service';
import { AddressType } from '../address-type.model';
import { AddressTypeService } from '../address-type.service';
import { Address } from '../address.model';
import { AddressService } from '../address.service';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css']
})
export class AddressEditComponent implements OnInit, OnChanges {

  public form: FormGroup;
  public errorMessage: string;
  public searchResultAddressTypes: AddressType[];
  @Input('EmployeeID') employeeID: number;

  constructor(private fb: FormBuilder,
              private serviceData: AddressService,
              private dialogService: DialogService,
              private addressTypeService: AddressTypeService,
              private dialog: MatDialog,
              private activatedRoute: ActivatedRoute,
              private route: Router) {

    this.errorMessage = '';
  }
   


  ngOnInit() {
    this.form = this.fb.group({
      AddressID: [null, [Validators.required]],      
      EmployeeID: [null, [Validators.required, Validators.min(1)]],
      AddressTypeID: [null, [Validators.required, Validators.min(1)]],
      Line1: [null, [Validators.required, Validators.maxLength(128)]],
      City: [null, [Validators.required, Validators.maxLength(32)]],
      State: [null, [Validators.required, Validators.maxLength(32)]],
      Country: [null, [Validators.required, Validators.maxLength(32)]],
      ZipCode: [null, [Validators.required, Validators.maxLength(32)]]
    });

    this.addressTypeService.getAll('Name','asc',null)
      .pipe(
        tap((items) => this.searchResultAddressTypes = items))
      .subscribe();
  }

  ngOnChanges(changes: SimpleChanges): void {
    
    if (changes) {
      this.serviceData.getByEmployee(this.employeeID)
        .pipe(
          tap((item) => {
            if (item) {
              this.displayItem(item)
            }
            else {
              this.initialize();
            }
          }),
          catchError(() => {
            this.initialize();
            return of({});
          })
        )
        .subscribe(
          null,
          (error) => this.errorMessage = error);
    }
  }

  submit(): void {

    if (this.form.valid) {
      if (this.form.dirty) {

        let newItem: Address = this.form.value;

        if (newItem.AddressID === 0) {
          this.serviceData.insert(newItem)
            .subscribe(
              (item: Address) => {
                this.form.get('AddressID').setValue(item.AddressID);
                this.onSubmitComplete();

              },
              (error: any) => {

                this.errorMessage = <any>
                  error;
              }
            );
        } else {
          this.serviceData.update(newItem.AddressID, newItem)
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
      AddressID: 0,      
      EmployeeID: this.employeeID,
      AddressTypeID: 0,
      Line1: null,
      City: null,
      State: null,
      Country: null,
      ZipCode: null
    });
  }

  openDeleteDialog(): void {

    this.dialogService.confirm('Do you really want to delete this address')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('AddressID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/addresss']));
  }

  deleteItem(itemID: number) {

    if (itemID > 0) {
      this.serviceData.delete(itemID)
        .subscribe(
          (item: Address) => {
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

  displayItem(item: Address): void {

    if (this.form) {
      this.form.reset();
    }

    this.form.patchValue({
      ...item
    });
  }


}
