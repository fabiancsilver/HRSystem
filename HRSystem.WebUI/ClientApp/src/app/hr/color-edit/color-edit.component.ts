import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { EMPTY, of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { DialogService } from '../../core/dialog.service';

import { Color } from '../color.model';
import { ColorService } from '../color.service';

@Component({
  selector: 'app-color-edit',
  templateUrl: './color-edit.component.html',
  styleUrls: ['./color-edit.component.css']
})
export class ColorEditComponent implements OnInit {

  public form: FormGroup;  
  public errorMessage: string;

  constructor(private fb: FormBuilder,
              private serviceData: ColorService,
              private dialogService: DialogService,
              private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private route: Router,
  ) {

    this.errorMessage = '';
  }


  ngOnInit() {
    this.form = this.fb.group({
      ColorID: [null, [Validators.required]],      
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

        let newItem: Color = this.form.value;

        if (newItem.ColorID === 0) {
          this.serviceData.insert(newItem)
            .subscribe(
              (item: Color) => {
                this.form.get('ColorID').setValue(item.ColorID);
                this.onSubmitComplete();
                
              },
              (error: any) => {
                
                this.errorMessage = <any>
                  error;
              }
            );
        } else {
          this.serviceData.update(newItem.ColorID, newItem)
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
      ColorID: 0,
      Name: null
    });
  }

  openDeleteDialog(): void {

    this.dialogService.confirm('Do you really want to delete this color')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('ColorID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigate(['/colors']));    
  }

  deleteItem(itemID: number) {

    if (itemID > 0) {
      this.serviceData.delete(itemID)
        .subscribe(
          (item: Color) => {                        
          },
          (error: any) => {
            this.errorMessage = <any> error;
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

  displayItem(item: Color): void {

    if (this.form) {
      this.form.reset();
    }

    this.form.patchValue({
      ColorID: item.ColorID,      
      Name: item.Name ? item.Name : null
    });
  }

 
}
