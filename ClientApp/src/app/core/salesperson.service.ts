import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable, } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { ISalesperson, ISalespersonReport } from '../shared/interfaces';

@Injectable()
export class SalespersonService {
  baseUrl = 'api/';
  baseCustomersUrl = this.baseUrl + 'salespersons';

  constructor(private http: HttpClient) { }

  getSalespersons(): Observable<ISalesperson[]> {
    return this.http.get<ISalesperson[]>(this.baseCustomersUrl)
      .pipe(
        map(salespersons => {
          //this.calculateCustomersOrderTotal(customers);
        return salespersons;
        }),
        catchError(this.handleError)
      );
  }

  getSalespersonsReport(): Observable<ISalespersonReport[]> {
    let reportUrl = this.baseCustomersUrl + '/report'
    return this.http.get<ISalespersonReport[]>(reportUrl)
      .pipe(
        map(salespersonsreport => {
          //this.calculateQuaterlyCommisions();
        return salespersonsreport;
        }),
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
