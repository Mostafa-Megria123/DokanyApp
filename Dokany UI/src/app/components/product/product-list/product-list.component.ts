import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/Products/product.service';
import { CategoryService } from 'src/app/Services/Category/category.service';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/models/Product';
import { ProductImage } from 'src/app/models/ProductImage';

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
  images: any[];
  productId: Number = 0;
  product: Product = null;
  categoryName: String = '';
  cols = [
    { class: 'col-5', field: 'productId', header: 'Id' },
    { class: 'col-15', field: 'non', header: 'Image' },
    { class: 'col-15', field: 'productName', header: 'Name' },
    { class: 'col-15', field: 'brandName', header: 'Brand Name' },
    { class: 'col-10', field: 'price', header: 'Price' },
    { class: 'col-10', field: 'quantity', header: 'Quantity' },
    { class: 'col-10', field: 'categoryId', header: 'Category' },
    { class: 'col-15', field: 'creationDate', header: 'Creation Date' },
    { class: 'col-7', field: 'non', header: '' },
    { class: 'col-7', field: 'non', header: '' },
    { class: 'col-7', field: 'non', header: '' }
  ];

  ngOnInit() {
    this._productService.getAll().subscribe(data => {
      this.prodcuts = data;
    });

    this._categoryService.getAll().subscribe(res => {
      this.categories = res;
    });
    this.images = [];
  }

  OnShowDetail(productId) {
    this.product = this.prodcuts.find(p => p.productId == productId);
    this.categoryName = this.getCategoryName(this.product['categoryId']);
    this._productService.GetImagesPaths(productId).subscribe(res => {
      var ProductImage = res as ProductImage[];
      this.images = [];
      ProductImage.forEach(item => {
        this.images.push({ source : this.getImage(item['imagePath']) });
      });
    });
  }

  OnSetIdForDelete(productId) {
    this.productId = productId;
  }

  OnDelete() {
    this._productService.delete(this.productId).subscribe(res => { }, err => {
      this.toastr.error('Some error happen!');
    }, () => {
      let prodIndex = this.prodcuts.findIndex(p => p.productId = this.productId);
      this.prodcuts.splice(prodIndex, 1);
      this.toastr.success('Category Deleted Successfully.');
    });
  }

  getCategoryName(categoryId) {
    if (this.categories != null)
      return this.categories.find(c => c.categoryId = categoryId).categoryName;
  }

  getImage(imageUrl) {
    return this._productService.LoadImage(imageUrl);
  }
}
