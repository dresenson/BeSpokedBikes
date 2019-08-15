import { Component, OnInit } from '@angular/core';
import { Sorter } from '../core/sorter';
import { ICustomer } from '../shared/interfaces';
import { CustomerService } from '../core/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  title: string;
  customers: ICustomer[] = [];
  constructor(private sorter: Sorter, private customerService: CustomerService) { }

  ngOnInit() {
    this.title = 'Customers';
    this.getCustomers()
  }

  getCustomers() {

    this.customerService.getCustomers()
      .subscribe((response: ICustomer[]) => { this.customers = response; },
      (err: any) => console.log(err),
      () => console.log('getCustomersPage() retrieved customers'))
  }

  sort(prop: string) {
    this.sorter.sort(this.customers, prop);
  }
}
