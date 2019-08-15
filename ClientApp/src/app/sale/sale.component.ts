import { Component, OnInit } from '@angular/core';
import { Sorter } from '../core/sorter';
import { ISale } from '../shared/interfaces';
import { SaleService } from '../core/sale.service';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.css']
})
export class SaleComponent implements OnInit {

  title: string;
  sales: ISale[] = [];
  constructor(private sorter: Sorter, private saleService: SaleService) { }

  ngOnInit() {
    this.title = 'Sales';
    this.getSales()
  }

  getSales() {

    this.saleService.getSales()
      .subscribe((response: ISale[]) => { this.sales = response; },
        (err: any) => console.log(err),
      () => console.log('getSales() retrieved sales'))
  }

  sort(prop: string) {
    this.sorter.sort(this.sales, prop);
  }
}
