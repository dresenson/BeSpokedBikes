import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable, } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { ISale } from '../shared/interfaces';

@Injectable()
export class SaleService {
  baseUrl = 'api/';
  baseCustomersUrl = this.baseUrl + 'sales';

  constructor(private http: HttpClient) { }

  getSales(): Observable<ISale[]> {
    return this.http.get<ISale[]>(this.baseCustomersUrl)
      .pipe(
        map(sales => {
            return sales;
        }),
        catchError(this.handleError)
      );
  }

  getSale(id: string): Observable<ISale> {
    return this.http.get<ISale>(this.baseCustomersUrl + '/' + id)
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
