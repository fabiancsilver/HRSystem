import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';

import { AddressEditComponent } from '../hr/address-edit/address-edit.component';
import { ColorEditComponent } from '../hr/color-edit/color-edit.component';
import { ColorListComponent } from '../hr/color-list/color-list.component';
import { DepartmentEditComponent } from '../hr/department-edit/department-edit.component';
import { DepartmentListComponent } from '../hr/department-list/department-list.component';
import { EmailEditComponent } from '../hr/email-edit/email-edit.component';
import { EmployeeEditComponent } from '../hr/employee-edit/employee-edit.component';
import { EmployeeListComponent } from '../hr/employee-list/employee-list.component';
import { PhoneEditComponent } from '../hr/phone-edit/phone-edit.component';
import { PositionEditComponent } from '../hr/position-edit/position-edit.component';
import { PositionListComponent } from '../hr/position-list/position-list.component';
import { ShiftEditComponent } from '../hr/shift-edit/shift-edit.component';
import { ShiftListComponent } from '../hr/shift-list/shift-list.component';
import { StatusEditComponent } from '../hr/status-edit/status-edit.component';
import { StatusListComponent } from '../hr/status-list/status-list.component';
import { MaterialModule } from '../material.module';
import { PhoneTypeListComponent } from '../hr/phone-type-list/phone-type-list.component';
import { PhoneTypeEditComponent } from '../hr/phone-type-edit/phone-type-edit.component';
import { EmailTypeEditComponent } from '../hr/email-type-edit/email-type-edit.component';
import { EmailTypeListComponent } from '../hr/email-type-list/email-type-list.component';
import { AddressTypeListComponent } from '../hr/address-type-list/address-type-list.component';
import { AddressTypeEditComponent } from '../hr/address-type-edit/address-type-edit.component';
import { WeeklyHireNumberComponent } from '../reports/weekly-hire-number/weekly-hire-number.component';
import { TerminatedNumberComponent } from '../reports/terminated-number/terminated-number.component';
import { NumberOfEmployeeDepartmentComponent } from '../reports/number-of-employee-department/number-of-employee-department.component';
import { NumberOfEmployeeManagerComponent } from '../reports/number-of-employee-manager/number-of-employee-manager.component';
import { ReportShellComponent } from '../reports/report-shell/report-shell.component';
import { UploadPhotoComponent } from '../hr/upload-photo/upload-photo.component';
import { PermissionByEmployeeListComponent } from '../hr/permission-by-employee-list/permission-by-employee-list.component';
import { PermissionEmployeeListComponent } from '../hr/permission-employee-list/permission-employee-list.component';
import { TreeHierarchyViewComponent } from '../reports/tree-hierarchy-view/tree-hierarchy-view.component';
import { HRDashboardComponent } from '../reports/hr-dashboard/hr-dashboard.component';


const routes: Routes = [
  { path: 'employees', component: EmployeeListComponent },
  { path: 'employees/:id', component: EmployeeEditComponent },
  
  { path: 'addresses/:id', component: AddressEditComponent },
  { path: 'addressTypes', component: AddressTypeListComponent },
  { path: 'addressTypes/:id', component: AddressTypeEditComponent },

  { path: 'emails/:id', component: EmailEditComponent },
  { path: 'emailTypes', component: EmailTypeListComponent },
  { path: 'emailTypes/:id', component: EmailTypeEditComponent },

  { path: 'phones/:id', component: PhoneEditComponent },
  { path: 'phoneTypes', component: PhoneTypeListComponent },
  { path: 'phoneTypes/:id', component: PhoneTypeEditComponent },

  { path: 'positions', component: PositionListComponent },
  { path: 'positions/:id', component: PositionEditComponent },
  { path: 'departments', component: DepartmentListComponent },
  { path: 'departments/:id', component: DepartmentEditComponent },
  { path: 'statuses', component: StatusListComponent },
  { path: 'statuses/:id', component: StatusEditComponent },
  { path: 'shifts', component: ShiftListComponent },
  { path: 'shifts/:id', component: ShiftEditComponent },
  { path: 'colors', component: ColorListComponent },
  { path: 'colors/:id', component: ColorEditComponent },

  { path: 'reports', component: ReportShellComponent },
  { path: 'hrDashboard', component: HRDashboardComponent },
  { path: 'treeHierarchyView', component: TreeHierarchyViewComponent },
  { path: 'weeklyHireNumber', component: WeeklyHireNumberComponent },
  { path: 'terminatedNumber', component: TerminatedNumberComponent },
  { path: 'numberOfEmployeeDepartment', component: NumberOfEmployeeDepartmentComponent },
  { path: 'numberOfEmployeeManager', component: NumberOfEmployeeManagerComponent }  
];

@NgModule({
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,    
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    RouterModule.forChild(routes) 
    
  ],
  declarations: [
    EmployeeListComponent,
    EmployeeEditComponent,
    AddressEditComponent,
    EmailEditComponent,
    PositionEditComponent,
    PositionListComponent,
    DepartmentListComponent,
    DepartmentEditComponent,
    StatusEditComponent,
    StatusListComponent,
    ShiftListComponent,
    ShiftEditComponent,
    ColorEditComponent,
    ColorListComponent,
    PhoneEditComponent,
    PhoneTypeListComponent,
    PhoneTypeEditComponent,
    EmailTypeEditComponent,
    EmailTypeListComponent,
    AddressTypeListComponent,
    AddressTypeEditComponent,
    WeeklyHireNumberComponent,
    TerminatedNumberComponent,
    NumberOfEmployeeDepartmentComponent,
    NumberOfEmployeeManagerComponent,
    ReportShellComponent,
    UploadPhotoComponent,
    PermissionByEmployeeListComponent,
    PermissionEmployeeListComponent,
    TreeHierarchyViewComponent,
    HRDashboardComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class HRModule {

}
