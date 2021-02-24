import { Component, OnInit } from '@angular/core';
import { ReportService } from '../report.service';
import { WeeklyHireNumber } from '../weekly-hire-number.model';

@Component({
  selector: 'app-weekly-hire-number',
  templateUrl: './weekly-hire-number.component.html',
  styleUrls: ['./weekly-hire-number.component.css']
})
export class WeeklyHireNumberComponent implements OnInit {

  public dataSource: Array<WeeklyHireNumber> = [];

  public displayedColumns: string[] = [
    'Year',
    'Week',
    'HireNumber'];

  constructor(private reportService: ReportService) {

  }

  ngOnInit(): void {
    this.reportService.getWeeklyHireNumbers()
      .subscribe(
        (result) => this.dataSource = result);
      
  }

}
