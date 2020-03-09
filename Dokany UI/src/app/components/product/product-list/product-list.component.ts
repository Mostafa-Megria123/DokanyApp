import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/Products/product.service';
import { CategoryService } from 'src/app/Services/Category/category.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private _productService: ProductService, 
    private _categoryService: CategoryService,
    private toastr: ToastrService
) { }

  prodcuts = null;
  categories = null;
  productId: Number = 0;

  ngOnInit() {
    this._productService.getAll().subscribe(data => {
      this.prodcuts = data;
    });

    this._categoryService.getAll().subscribe(res => {
      this.categories = res;
    });
  }

  OnSetIdForDelete(productId){
    this.productId = productId;
  }

  OnDelete(){
    this._productService.delete(this.productId).subscribe(res => {} , err => {
      this.toastr.error('Some error happen!');
    } , () => {
      let prodIndex= this.prodcuts.findIndex(p => p.productId = this.productId);
      this.prodcuts.splice(prodIndex , 1);
      this.toastr.success('Category Deleted Successfully.');
    });
  }

  getCategoryName(categoryId){
    return this.categories.find(c => c.categoryId = categoryId).categoryName;
  }

  getImage(imageUrl){
    return this._productService.LoadImage(imageUrl);
  }
}
