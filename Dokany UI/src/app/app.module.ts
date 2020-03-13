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
import { FormProductComponent } from './components/product/form-product/form-product.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { FormCategoryComponent } from './components/category/form-category/form-category.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { Step1Component } from './components/order-wizard/step1/step1.component';
import { Step2Component } from './components/order-wizard/step2/step2.component';
import { Step3Component } from './components/order-wizard/step3/step3.component';
import { LastStepComponent } from './components/order-wizard/last-step/last-step.component';
import { OrderSummaryComponent } from './components/order-wizard/order-summary/order-summary.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LayoutComponent } from './components/shared/layout/layout.component';
import { StepperComponent } from './components/order-wizard/stepper/stepper.component';
import { LeftNavbarComponent } from './shared/left-navbar/left-navbar.component';
import { FormOrderComponent } from './components/order/form-order/form-order.component';
import { OrderListComponent } from './components/order/order-list/order-list.component';

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
    OrderListComponent
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
