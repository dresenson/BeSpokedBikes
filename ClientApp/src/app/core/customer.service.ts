import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable, } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { ICustomer } from '../shared/interfaces';

@Injectable()
export class CustomerService {
  baseUrl = 'api/';
  baseCustomersUrl = this.baseUrl + 'customers';

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<ICustomer[]> {
    return this.http.get<ICustomer[]>(this.baseCustomersUrl)
      .pipe(
        map(customers => {
          //this.calculateCustomersOrderTotal(customers);
          return customers;
        }),
        catchError(this.handleError)
      );
  }

  getCustomer(id: string): Observable<ICustomer> {
    return this.http.get<ICustomer>(this.baseCustomersUrl + '/' + id)
      .pipe(
        catchError(this.handleError)
      );
  }
  
   private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      let errMessage = error.error.message;
      return Observable.throw(errMessage);
    }
    return Observable.throw(error || 'ASP.NET Core server error');
  }

}
