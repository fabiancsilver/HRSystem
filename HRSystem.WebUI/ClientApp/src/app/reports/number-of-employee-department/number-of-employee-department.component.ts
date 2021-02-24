import { Component, OnInit } from '@angular/core';
import { NumberOfEmployeeDepartment } from '../number-of-employee-department.model';
import { ReportService } from '../report.service';

@Component({
  selector: 'app-number-of-employee-department',
  templateUrl: './number-of-employee-department.component.html',
  styleUrls: ['./number-of-employee-department.component.css']
})
export class NumberOfEmployeeDepartmentComponent implements OnInit {

  public dataSource: Array<NumberOfEmployeeDepartment> = [];

  public displayedColumns: string[] = [
    'Department',    
    'Quantity'];

  constructor(private reportService: ReportService) {

  }

  ngOnInit(): void {
    this.reportService.getNumberOfEmployeeDepartments()
      .subscribe(
        (result) => this.dataSource = result);      
  }
}
