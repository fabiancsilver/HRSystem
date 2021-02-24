import { Component, OnInit } from '@angular/core';
import { NumberOfEmployeeManager } from '../number-of-employee-manager.model';
import { ReportService } from '../report.service';
import { TerminatedNumber } from '../terminated-number.model';

@Component({
  selector: 'app-number-of-employee-manager',
  templateUrl: './number-of-employee-manager.component.html',
  styleUrls: ['./number-of-employee-manager.component.css']
})
export class NumberOfEmployeeManagerComponent implements OnInit {

  public dataSource: Array<NumberOfEmployeeManager> = [];

  public displayedColumns: string[] = [
    'Manager',    
    'Quantity'];

  constructor(private reportService: ReportService) {

  }

  ngOnInit(): void {
    this.reportService.getNumberOfEmployeeManagers()
      .subscribe(
        (result) => this.dataSource = result);      
  }
}
