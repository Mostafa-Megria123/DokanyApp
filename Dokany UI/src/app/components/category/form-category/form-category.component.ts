import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/Category';
import { CategoryService } from 'src/app/Services/Category/category.service';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'form-category',
  templateUrl: './form-category.component.html',
  styleUrls: ['./form-category.component.css']
})
export class FormCategoryComponent implements OnInit {


  constructor(
    private _http: HttpClient,
    private _categoryService: CategoryService,
    private _route: ActivatedRoute,
    private toastr: ToastrService,
    private _router: Router) { }

  //#region Properties
  formCategory = new FormGroup({
    categoryName: new FormControl(),
    categoryDescription: new FormControl()
  });
  categoryId: Number = 0;
  formData = new FormData();
  progress: number;
  message: string;
  imageUrl: String = '';
  selectedImage: boolean = false;
  //#endregion

  ngOnInit() {
    this._route.paramMap.subscribe(data => {
      this.categoryId = +data.get('id');
      if (this.categoryId != 0)
        this._categoryService.get(this.categoryId).subscribe(category => {
          this.formCategory = new FormGroup({
            categoryName: new FormControl(category['categoryName']),
            categoryDescription: new FormControl(category['description'])
          });
          this.imageUrl = category['imagePath']
        });
    });
  }

  OnSubmit() {

    if (this.categoryId == 0) {
      this._categoryService.UploadImage(this.formData)
        .subscribe(event => {
          if (event.type === HttpEventType.UploadProgress)
            this.progress = Math.round(100 * event.loaded / event.total);
          else if (event.type === HttpEventType.Response) {
            this.message = 'Upload success.';
            this.toastr.success('Category Added Successfully.');
            this._router.navigate(['/dashBoard/categories']);
          }
          if (event['body'] != undefined) {
            this._categoryService.add(new Category(
              0,
              this.formCategory.value.categoryName,
              this.formCategory.value.categoryDescription,
              event['body'].dbPaths[0]
            )).subscribe(res => {
            }, err => { },
              () => {
              }
            );
          }
        });
    }
    else if (this.categoryId > 0) {
      this._categoryService.UploadImage(this.formData)
        .subscribe(event => {
          if (event.type === HttpEventType.UploadProgress)
            this.progress = Math.round(100 * event.loaded / event.total);
          else if (event.type === HttpEventType.Response) {
            this.message = 'Upload success.';
          }

          if (event['body'] != undefined) {
            this._categoryService.update(this.categoryId, new Category(
              this.categoryId,
              this.formCategory.value.categoryName,
              this.formCategory.value.categoryDescription,
              event['body'].dbPaths.length != 0 ? event['body'].dbPaths[0] : this.imageUrl
            )).subscribe(res => {
            }, err => { },
              () => {
                this.toastr.success('Category Updated Successfully');
                this._router.navigate(['/dashBoard/categories']);
              });
          }
        });


    }

  }

  uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    this.message = fileToUpload.name;
    this.formData.append('file', fileToUpload, fileToUpload.name);
    this.selectedImage = true;
  }

}
