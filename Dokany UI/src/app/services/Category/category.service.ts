import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from 'src/app/models/Category';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  url = 'http://localhost:53847/';
  constructor(private _http: HttpClient) { }

  getAll() {
    return this._http.get(this.url + 'api/Category');
  }

  get(CategoryId: Number) {
    return this._http.get(this.url + 'api/Category/' + CategoryId);
  }

  add(category: Category) {
    return this._http.post(this.url + 'api/Category/AddCategory', category);
  }

  update(CategoryId: Number , Category: Category){
    return this._http.post(this.url + 'api/Category/UpdateCategory' , Category);
  }

  delete(CategoryId: Number) {
    return this._http.delete(this.url + 'api/Category?id=' + CategoryId);
  }

  UploadImage(formData: FormData) {
    return this._http.post(this.url + 'api/upload', formData, { reportProgress: true, observe: 'events' });
  }

  LoadImage(imagePath) {
    return this.url + "api/Upload?imagePath=" + imagePath;
  }
}
