import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShippingAddress } from 'src/app/admin/models/order-wizard/ShippingAddress';


@Component({
  selector: 'order-step3',
  templateUrl: './step3.component.html',
  styleUrls: ['./step3.component.css']
})
export class Step3Component implements OnInit {

  @Input() shippingAddress: ShippingAddress = new ShippingAddress(0 , '' , '' , '' ,'' , '');
  @Input() selectPaymentType: String = null;
 
  @Output() selectStep: EventEmitter<Number> = new EventEmitter<Number>();
  ngOnInit() {

  }

  OnEditShippingAddress(index){
    this.selectStep.emit(index);
  }

}
