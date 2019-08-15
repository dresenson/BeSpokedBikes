import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomerComponent } from './customer/customer.component';

import { CustomerService } from './core/customer.service';
import { SalespersonComponent } from './salesperson/salesperson.component';
import { SalespersonService } from './core/salesperson.service';
import { ProductComponent } from './product/product.component';
import { ProductService } from './core/product.service';
import { SaleComponent } from './sale/sale.component'
import { SaleService } from './core/sale.service';
import { SalespersonreportComponent } from './salespersonreport/salespersonreport.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CustomerComponent,
    SalespersonComponent,
    ProductComponent,
    SaleComponent,
    SalespersonreportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ProductComponent, pathMatch: 'full' },
      { path: 'customers', component: CustomerComponent },
      { path: 'salespersons/report', component: SalespersonreportComponent },
      { path: 'salespersons', component: SalespersonComponent },
      { path: 'products', component: ProductComponent },
      { path: 'sales', component: SaleComponent },
      
    ])
  ],
  providers: [CustomerService, SalespersonService, ProductService, SaleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
