import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/Category/category.service';
import { Category } from 'src/app/models/Category';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'categories-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  constructor(private _categoryService: CategoryService,
    private toastr: ToastrService
  ) { }
  categories: Category[] = null;
  categoryId: Number = 0;

  cols = [
    { class: 'col-5', field: 'categoryId', header: 'Id' },
    { class: 'col-10', field: 'non', header: 'Image' },
    { class: 'col-15', field: 'categoryName', header: 'Name' },
    { class: 'col-20', field: 'description', header: 'Description' },
    { class: 'col-5', field: 'non', header: '' },
    { class: 'col-5', field: 'non', header: '' }
  ];
  ngOnInit() {
    this._categoryService.getAll().subscribe(data => {
      this.categories = data as Category[];
    });

  }

  OnSetIdForDelete(categoryId) {
    this.categoryId = categoryId;
  }

  OnDelete() {
    this._categoryService.delete(this.categoryId).subscribe(res => {
      let categIndex = this.categories.findIndex(c => c.Id == this.categoryId);
      this.categories.splice(categIndex, 1);
      this.toastr.success('Category Deleted Successfully.');

    }, err => {
      this.toastr.error('Some error happen!');
    });
  }

  getImage(imagePath) {
    return this._categoryService.LoadImage(imagePath);
  }

}
