import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/Category';
import { CategoryService } from 'src/app/Services/Category/category.service';

@Component({
  selector: 'form-category',
  templateUrl: './form-category.component.html',
  styleUrls: ['./form-category.component.css']
})
export class FormCategoryComponent implements OnInit {

  
  constructor(
    private _categoryService: CategoryService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  formCategory = new FormGroup({
    categoryName: new FormControl()
  });

  categoryId: Number = 0;

  ngOnInit() {
    this._route.paramMap.subscribe(data => {
      this.categoryId = +data.get('id');
      if (this.categoryId != 0)
        this._categoryService.get(this.categoryId).subscribe(category => {
          this.formCategory = new FormGroup({
            categoryName: new FormControl(category.Name)
          });
        });
    });
  }

  OnSubmit() {
    if (this.categoryId == 0)
      this._categoryService.add(new Category(
        this._categoryService.categories.length + 1,
        this.formCategory.value.categoryName
      ));
    else if (this.categoryId > 0)
      this._categoryService.update(this.categoryId,
        new Category(this.categoryId, this.formCategory.value.categoryName));

    this._router.navigate(['/home/categories']);
  }

  // OnCancel() {
  //   this._router.navigate(['categories']);
  // }
}
