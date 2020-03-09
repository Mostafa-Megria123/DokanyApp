import { Component, OnInit} from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpEventType } from '@angular/common/http';

import { ProductService } from 'src/app/Services/Products/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/Services/Category/category.service';
import { Category } from 'src/app/models/Category';
import { Product } from 'src/app/models/Product';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'product-form',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css']
})
export class FormProductComponent implements OnInit {

  constructor(
    private _productService: ProductService,
    private _categoryService: CategoryService,
    private _route: ActivatedRoute,
    private _router: Router,
    private toastr: ToastrService,
  ) { }

  //#region Properties
  productForm = new FormGroup({
    productName: new FormControl(),
    brandName: new FormControl(),
    quantity: new FormControl(),
    price: new FormControl(),
    category: new FormControl(),
    description: new FormControl(),
  });
  productId: Number = 0;
  formData = new FormData();
  categories = [];
  imageUrl: String = '';
  progress: number;
  message: string;
  //#endregion

  ngOnInit() {
    this._route.paramMap.subscribe(data => {
      this.productId = +data.get('id');
      if (this.productId != 0)
        this._productService.get(this.productId).subscribe(product => {
          this.productForm = new FormGroup({
            productName: new FormControl(product['productName']),
            brandName: new FormControl(product['brandName']),
            quantity: new FormControl(product['quantity']),
            price: new FormControl(product['price']),
            category: new FormControl(product['categoryId']),
            description: new FormControl(product['description']),
          });
          this.imageUrl = product['imageUrl'];
        });
    });

    this._categoryService.getAll().subscribe(data => {
      this.categories = data as Category[];
    });
  }

  OnSubmit() {
    if (this.productId == 0) {
      this._productService.UploadImage(this.formData).subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
        }

        if (event['body'] != undefined) {
          this._productService.add(new Product(
            0,
            this.productForm.value.productName,
            this.productForm.value.brandName,
            this.productForm.value.quantity,
            this.productForm.value.price,
            this.productForm.value.category,
            this.productForm.value.description,
            null, // creation date set in backend
            event['body'].dbPaths
          )).subscribe(res => { }, err => { }, () => {
            this.toastr.success('Product Added Successfully.');
            this._router.navigate(['/home/product']);
          });
        }
      });
    }

    else if (this.productId > 0)
      this._productService.update(new Product(
        this.productId,
        this.productForm.value.productName,
        this.productForm.value.brandName,
        this.productForm.value.quantity,
        this.productForm.value.price,
        this.productForm.value.category,
        this.productForm.value.description,
        null, // creation date set in backend
        event['body'] != undefined ? event['body'].dbPaths : [this.imageUrl]
      )).subscribe(res => { }, err => { }, () => {
        this.toastr.success('Product Updated Successfully');
        this._router.navigate(['/home/product']);
      });
  }

  uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    this.message = fileToUpload.name;
    this.formData.append('file', fileToUpload, fileToUpload.name);
  }

}
