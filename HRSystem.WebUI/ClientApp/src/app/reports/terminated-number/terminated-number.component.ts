import { Component, OnInit } from '@angular/core';
import { ReportService } from '../report.service';
import { TerminatedNumber } from '../terminated-number.model';

@Component({
  selector: 'app-terminated-number',
  templateUrl: './terminated-number.component.html',
  styleUrls: ['./terminated-number.component.css']
})
export class TerminatedNumberComponent implements OnInit {

  public dataSource: Array<TerminatedNumber> = [];

  public displayedColumns: string[] = [
    'Year',    
    'TerminatedNumber'];

  constructor(private reportService: ReportService) {

  }

  ngOnInit(): void {
    this.reportService.getTerminatedNumbers()
      .subscribe(
        (result) => this.dataSource = result);      
  }
}
