import { Component, OnInit } from '@angular/core';
import { ISalespersonReport } from '../shared/interfaces';
import { SalespersonService } from '../core/salesperson.service';

@Component({
  selector: 'app-salespersonreport',
  templateUrl: './salespersonreport.component.html',
  styleUrls: ['./salespersonreport.component.css']
})
export class SalespersonreportComponent implements OnInit {

  title: string;
  salespersonsreport: ISalespersonReport[] = [];
  constructor(private salespersonService: SalespersonService) { }

  ngOnInit() {
    this.title = 'Salespersons Report';
    this.getSalespersonsReport()
  }

  getSalespersonsReport() {

    this.salespersonService.getSalespersonsReport()
      .subscribe((response: ISalespersonReport[]) => { this.salespersonsreport = response; },
        (err: any) => console.log(err),
        () => console.log('getSalespersons() retrieved salespersons'))
  }
}
