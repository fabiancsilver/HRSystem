import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../hr/employee.service';
import { ReportService } from '../report.service';
import { RetentionRate } from '../retention-rate.model';

@Component({
  selector: 'app-hr-dashboard',
  templateUrl: './hr-dashboard.component.html',
  styleUrls: ['./hr-dashboard.component.css']
})
export class HRDashboardComponent implements OnInit {


  retentionRate: RetentionRate;

  constructor(private reportsService: ReportService) {
    this.reportsService.getRetentionRate()
      .subscribe((result) =>
        this.retentionRate = result);
  }

  ngOnInit(): void {

  }
}
