import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable, } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IProduct } from '../shared/interfaces';

@Injectable()
export class ProductService {
  baseUrl = 'api/';
  baseCustomersUrl = this.baseUrl + 'products';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<IProduct[]> {
    return this.http.get<IProduct[]>(this.baseCustomersUrl)
      .pipe(
        map(products => {
          //this.calculateCustomersOrderTotal(customers);
        return products;
        }),
        catchError(this.handleError)
      );
  }

  getProduct(id: string): Observable<IProduct> {
    return this.http.get<IProduct>(this.baseCustomersUrl + '/' + id)
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
