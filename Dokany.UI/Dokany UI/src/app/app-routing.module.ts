import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { FormProductComponent } from './components/product/form-product/form-product.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { FormCategoryComponent } from './components/category/form-category/form-category.component';
import { StepperComponent } from './components/order-wizard/stepper/stepper.component';
import { LeftNavbarComponent } from './shared/left-navbar/left-navbar.component';

// eslam
// const routes: Routes = [
  
//   {path:'products' , component: ProductListComponent},
//   {path:'product/:id' , component: FormProductComponent},
//   {path:'categories' , component: CategoryListComponent},
//   {path:'category/:id' , component: FormCategoryComponent},
//   {path:'order' , component: StepperComponent},
// ];
// shery
const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {
      path: 'home', component: LeftNavbarComponent,
      children: [
          { path: 'product', component: ProductListComponent },
          { path: 'product/:id', component: FormProductComponent },
          { path: 'categories', component: CategoryListComponent },
          { path: 'category/:id', component: FormCategoryComponent },
          { path: 'order', component: StepperComponent },
          { path: '', redirectTo: 'product', pathMatch: 'full' },
      ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
