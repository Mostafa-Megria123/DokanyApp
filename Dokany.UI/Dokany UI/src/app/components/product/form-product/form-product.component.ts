import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpEventType, HttpClient } from '@angular/common/http';

import { ProductService } from 'src/app/Services/Products/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/Services/Category/category.service';
import { Category } from 'src/app/models/Category';
import { Product } from 'src/app/models/Product';

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
    private http: HttpClient
  ) { }

  categories: Category[] = null;
  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

  productForm = new FormGroup({
    productName: new FormControl(),
    quantity: new FormControl(),
    price: new FormControl(),
    category: new FormControl(),
    detail: new FormControl(),
  });
  productId: Number = 0;

  ngOnInit() {
    this._route.paramMap.subscribe(data => {
      this.productId = +data.get('id');
      if(this.productId !=0)
      this._productService.get(this.productId).subscribe(product => {
        this.productForm = new FormGroup({
          productName: new FormControl(product.Name),
          quantity: new FormControl(product.Quantity),
          price: new FormControl(product.Price),
          category: new FormControl(product.Category),
          detail: new FormControl(product.Detail),
        });
      });
    });

    this._categoryService.getAll().subscribe(data => {
      this.categories = data;
    });
  }

  OnSubmit() {
    if (this.productId == 0)
      this._productService.add(new Product(
        (+this._productService.count() + 1),
        this.productForm.value.productName,
        this.productForm.value.quantity,
        this.productForm.value.price,
        this.productForm.value.category,
        this.productForm.value.detail,
        null,
        null
      ));
    else if (this.productId > 0)
      this._productService.update(this.productId , new Product(
        this.productId,
        this.productForm.value.productName,
        this.productForm.value.quantity,
        this.productForm.value.price,
        this.productForm.value.category,
        this.productForm.value.detail,
        null,
        null
      ));

    this._router.navigate(['/home/product']);
  }

  uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
 
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
 
    this.http.post('https://localhost:5001/api/upload', formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }
      });
  }
  
  // OnCancel(){
  //   this._router.navigate(['/home/product']);
  // }
}
