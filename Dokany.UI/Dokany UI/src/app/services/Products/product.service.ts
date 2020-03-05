import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from 'src/app/models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }

  products: Product[] = [
    new Product(1 , 'product 1' , 2 , 100 , 'Mobile' , 'details' , null , null)
  ];

  getAll(): Observable<Product[]>{
    return of(this.products);
  }

  get(productId: Number): Observable<Product>{
    return of(this.products.find(p => p.Id == productId));
  }

  add(product: Product){
    this.products.push(product);
  }

  update(productId: Number , product: Product){
    let prod = this.products.find(p => p.Id == productId);
    prod.Name = product.Name;
    prod.Price = product.Price;
    prod.Category = product.Category;
  }

  delete(productId: Number){
    let index = this.products.findIndex(p => p.Id == productId);
    this.products.splice(index , 1 );
  }

  count(): Number{
    return this.products.length;
  }

}
