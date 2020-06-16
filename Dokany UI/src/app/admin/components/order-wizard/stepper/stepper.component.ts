import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/admin/models/order-wizard/Order';
import { NgWizardConfig, THEME, StepChangedArgs, NgWizardService, TOOLBAR_BUTTON_POSITION, TOOLBAR_POSITION } from 'ng-wizard';
import { ShippingAddress } from 'src/app/admin/models/order-wizard/ShippingAddress';
import { SubmitOrderService } from 'src/app/admin/services/Order-Wizard/Submit-Order/submit-order.service';
import { Credit } from 'src/app/admin/models/order-wizard/Credit';
import { $ } from 'protractor';

@Component({
  selector: 'order-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.css']
})
export class StepperComponent implements OnInit {
  config: NgWizardConfig = {
    toolbarSettings: {
      toolbarButtonPosition: TOOLBAR_BUTTON_POSITION.end
    },
    cycleSteps: true
  };

  numberOfStep: number = 1;

  ShippingAddress: ShippingAddress = null;
  CreditInfo: Credit = null;
  SelectPaymentType: String = null;
  IsLastStep: boolean = false;

  constructor(
    private ngWizardService: NgWizardService, 
    private submitOrderService: SubmitOrderService) {
  }

  ngOnInit() {
  }

  showPreviousStep(event?: Event) {
    this.ngWizardService.previous();
  }

  showNextStep(event?: Event) {

    this.ngWizardService.next();
  }

  resetWizard(event?: Event) {
    this.ngWizardService.reset();
  }

  setTheme(theme: THEME) {
    this.ngWizardService.theme(theme);
  }

  stepChanged(args: StepChangedArgs) {
    this.numberOfStep = args.step.index;
    if (this.numberOfStep == 2) {
      document.getElementById('btnNextWizard').innerHTML = "FINISH THE ORDER";
    } else {
      document.getElementById('btnNextWizard').innerHTML = `PROCEED TO STEP ${this.numberOfStep + 2} OF 3`;
    }

    if (this.numberOfStep == 0)
      document.getElementById('btnPrevWizard').innerHTML = `CONTINUE SHOPPING`;
    else
      document.getElementById('btnPrevWizard').innerHTML = `BACK TO STEP ${this.numberOfStep} OF 3`;

    if (this.numberOfStep == 3) { // Fisish Order
      this.IsLastStep = true;
     
      document.getElementsByClassName('checkOut')[0].innerHTML = "Order Placed!";
      document.getElementById('orderSummaryContainer').style.display = "none";
      
      this.SaveOrder();
    }

  }

  SetShippingAddress(event) {
    this.ShippingAddress = event;
  }
  SetPaymentType(event) {
    this.SelectPaymentType = event;
  }
  SetCreditInfo(event){
    this.CreditInfo = event;
  }

  SetStep(length) {
    for (let index = 0; index < length; index++) {
      this.ngWizardService.previous();
    }
  }

  ShowMyOrders() {
    alert('ShowMyOrders');
  }
  ContinueShopping() {
    alert('ContinueShopping');
  }

  
  SaveOrder(){
    /// Save Order to API.
    if(this.CreditInfo == null)
      this.submitOrderService.Post(new Order(this.ShippingAddress , this.SelectPaymentType.substring(0 , this.SelectPaymentType.indexOf(' ')) ,null));
    else
      this.submitOrderService.Post(new Order(this.ShippingAddress , this.SelectPaymentType.substring(0 , this.SelectPaymentType.indexOf(' ')) ,this.CreditInfo));
  }

}
