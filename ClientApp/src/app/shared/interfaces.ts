import { ModuleWithProviders } from '@angular/core';

export interface ICustomer {
    id?: number;
    firstName: string;
    lastName: string;
    address: string;
    phone: string;
    startDate: string;
}

export interface ISalesperson {
  id?: number;
  firstName: string;
  lastName: string;
  address: string;
  phone: string;
  startDate: string;
  terminationDate: string;
  manager: string;
}

export interface IProduct {
  id?: number;
  name: string;
  manufacturer: string;
  style: string;
  purchasePrice: number;
  discount: number;
  salePrice: number;
  qtyOnHand: number;
  commissionPercentage: number;
}

export interface ISale {
  id?: number;
  productName: string;
  customerName: string;
  saleDate: string;
  salePrice: number;
  salesperson: string;
  salespersonCommission: number;
}

export interface ISalespersonReport {
  salesperson: string;
  salespersonCommission: number;
  commissionDate: string;

}
