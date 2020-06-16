import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NoopAnimationsModule} from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import { GalleriaModule } from 'primeng/galleria';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgWizardModule, NgWizardConfig, THEME } from 'ng-wizard';
import { FormProductComponent } from './admin/components/product/form-product/form-product.component';
import { ProductListComponent } from './admin/components/product/product-list/product-list.component';
import { FormCategoryComponent } from './admin/components/category/form-category/form-category.component';
import { CategoryListComponent } from './admin/components/category/category-list/category-list.component';
import { Step1Component } from './admin/components/order-wizard/step1/step1.component';
import { Step2Component } from './admin/components/order-wizard/step2/step2.component';
import { Step3Component } from './admin/components/order-wizard/step3/step3.component';
import { LastStepComponent } from './admin/components/order-wizard/last-step/last-step.component';
import { OrderSummaryComponent } from './admin/components/order-wizard/order-summary/order-summary.component';
import { NavComponent } from './admin/components/shared/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LayoutComponent } from './admin/components/shared/layout/layout.component';
import { StepperComponent } from './admin/components/order-wizard/stepper/stepper.component';
import { LeftNavbarComponent } from './shared/left-navbar/left-navbar.component';
import { FormOrderComponent } from './admin/components/order/form-order/form-order.component';
import { OrderListComponent } from './admin/components/order/order-list/order-list.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './home/product/product.component';

const ngWizardConfig: NgWizardConfig = {
  theme: THEME.circles
};

@NgModule({
  declarations: [
    AppComponent,
    FormProductComponent,
    ProductListComponent,
    FormCategoryComponent,
    CategoryListComponent,
    Step1Component,
    Step2Component,
    Step3Component,
    LastStepComponent,
    OrderSummaryComponent,
    NavComponent,
    LayoutComponent,
    StepperComponent,
    LeftNavbarComponent,
    FormOrderComponent,
    OrderListComponent,
    HomeComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    NoopAnimationsModule,
    TableModule,
    MultiSelectModule,
    GalleriaModule,
    ToastrModule.forRoot({
      timeOut: 1000,
      positionClass: 'toast-bottom-right',
    }),
    NgWizardModule.forRoot(ngWizardConfig)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
