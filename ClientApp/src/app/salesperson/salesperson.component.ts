import { Component, OnInit } from '@angular/core';
import { ISalesperson } from '../shared/interfaces';
import { SalespersonService } from '../core/salesperson.service';

@Component({
  selector: 'app-salesperson',
  templateUrl: './salesperson.component.html',
  styleUrls: ['./salesperson.component.css']
})
export class SalespersonComponent implements OnInit {

  title: string;
  salespersons: ISalesperson[] = [];
  constructor(private salespersonService: SalespersonService) { }

  ngOnInit() {
    this.title = 'Salespersons';
    this.getSalespersons()
  }

  getSalespersons() {

    this.salespersonService.getSalespersons()
      .subscribe((response: ISalesperson[]) => { this.salespersons = response;},
        (err: any) => console.log(err),
      () => console.log('getSalespersons() retrieved salespersons'))
  }
}
