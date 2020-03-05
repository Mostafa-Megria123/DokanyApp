import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from 'src/app/models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor() { }

  categories: Category[] = [
   new Category(1 , 'Labtop')
  ];

  getAll(): Observable<Category[]>{
    return of(this.categories);
  }

  get(CategoryId: Number): Observable<Category>{
    return of(this.categories.find(p => p.Id == CategoryId));
  }

  add(Category: Category){
    this.categories.push(Category);
  }

  update(CategoryId: Number , Category: Category){
    let category = this.categories.find(p => p.Id == CategoryId);
    category.Name = Category.Name;
  }

  delete(CategoryId: Number){
    let index = this.categories.findIndex(p => p.Id == CategoryId);
    this.categories.splice(index , 1 );
  }
}
