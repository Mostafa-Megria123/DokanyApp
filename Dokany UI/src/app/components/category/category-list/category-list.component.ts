import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/Category/category.service';
import { Category } from 'src/app/models/Category';

@Component({
  selector: 'categories-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  constructor(private _categoryService: CategoryService) { }
  categories: Category[] = null;
  categoryId: Number = 0;

  ngOnInit() {
    this._categoryService.getAll().subscribe(data => {
      this.categories = data;
    });
  }

  OnSetIdForDelete(categoryId){
    this.categoryId = categoryId;
  }

  OnDelete(){
    this._categoryService.delete(this.categoryId);
  }

}
