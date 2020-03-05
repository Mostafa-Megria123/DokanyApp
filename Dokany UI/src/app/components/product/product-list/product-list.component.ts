import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/Product';
import { ProductService } from 'src/app/Services/Products/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private _productService: ProductService) { }

  prodcuts: Product[] = null;
  productId: Number = 0;
  ngOnInit() {
    this._productService.getAll().subscribe(data => {
      this.prodcuts = data;
    });
  }

  OnSetIdForDelete(productId){
    this.productId = productId;
  }

  OnDelete(){
    this._productService.delete(this.productId);
  }
}
