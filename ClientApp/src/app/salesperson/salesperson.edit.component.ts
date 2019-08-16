import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { SalespersonService } from '../core/salesperson.service';
import { ISalesperson } from '../shared/interfaces';

@Component({
  selector: 'salesperson-edit',
  templateUrl: './salesperson.edit.component.html'
})
export class SalespersonEditComponent implements OnInit {

  salesperson: ISalesperson = {
    firstName: '',
    lastName: '',
    address: '',
    phone: '',
    startDate: '',
    terminationDate: '',
    manager: ''
  };

  errorMessage: string;
  deleteMessageEnabled: boolean;
  operationText: string = 'Insert';

  constructor(private router: Router,
    private route: ActivatedRoute,
    private salespersonService: SalespersonService) { }

  ngOnInit() {
    let id = this.route.snapshot.params['id'];
    if (id !== '0') {
      this.operationText = 'Update';
      this.getSalesperson(id);
    }
  }

  getSalesperson(id: string) {
    this.salespersonService.getSalesperson(id)
      .subscribe((salesperson: ISalesperson) => {
        this.salesperson = salesperson;
      },
        (err: any) => console.log(err));
  }
}
