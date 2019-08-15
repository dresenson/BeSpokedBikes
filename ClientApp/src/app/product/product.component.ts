import { Component, OnInit } from '@angular/core';
import { Sorter } from '../core/sorter';
import { IProduct } from '../shared/interfaces';
import { ProductService } from '../core/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  title: string;
  products: IProduct[] = [];
  constructor(private sorter: Sorter, private productService: ProductService) { }

  ngOnInit() {
    this.title = 'Products';
    this.getProducts()
  }

  getProducts() {

    this.productService.getProducts()
      .subscribe((response: IProduct[]) => { this.products = response; },
        (err: any) => console.log(err),
      () => console.log('getProducts() retrieved products'))
  }

  sort(prop: string) {
    this.sorter.sort(this.products, prop);
  }
}
