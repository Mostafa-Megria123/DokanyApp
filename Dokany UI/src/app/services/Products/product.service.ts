import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from 'src/app/models/Product';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url = 'http://localhost:53847/';
  constructor(private _http: HttpClient) { }

  getAll(){
    return this._http.get(this.url + 'api/Product');
  }

  get(productId: Number){
    return this._http.get(this.url + 'api/Product/' + productId);  
  }

  add(product: Product){
    return this._http.post(this.url + 'api/Product/AddProduct' , product);
  }

  UploadImage(formData: FormData) {
    return this._http.post(this.url + 'api/upload', formData, { reportProgress: true, observe: 'events' });
  }
  update(product: Product){
    return this._http.post(this.url + 'api/Product/UpdateProduct' , product);
  }

  delete(productId: Number){
    return this._http.delete(this.url + 'api/Product?id=' + productId);
  }

  LoadImage(imageUrl){
    return this.url + "api/Upload?imagePath=" + imageUrl;
  }

  GetImagesPaths(productId: Number){
    return this._http.get(this.url + "api/Product/Images?productId=" + productId);
  }

}
