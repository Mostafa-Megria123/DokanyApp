import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Credit } from 'src/app/models/order-wizard/Credit';

@Component({
  selector: 'order-step2',
  templateUrl: './step2.component.html',
  styleUrls: ['./step2.component.css']
})
export class Step2Component implements OnInit {

  type = 'credit';
  cardName: String = null;
  cardNumber: String = null;
  month: String = null;
  year: Number = null;
  @Output() OnSelectPaymentType:  EventEmitter<String>  = new EventEmitter<String>();
  @Output() OnCreditInfo:  EventEmitter<Credit>  = new EventEmitter<Credit>();

  constructor() { }

  ngOnInit() {
  }

  OnPaymentType(paymentType) {
    if (paymentType == 'credit') {
      document.getElementById('credit').style.border = '3px solid red';
      document.getElementById('credit').style.color = 'red';
      document.getElementById('cash').style.border = '3px solid gray';
      document.getElementById('cash').style.color = 'gray';

      this.OnSelectPaymentType.emit('Credit Card');
    } else {
      document.getElementById('credit').style.border = '3px solid gray';
      document.getElementById('credit').style.color = 'gray';
      document.getElementById('cash').style.border = '3px solid red';
      document.getElementById('cash').style.color = 'red';

      this.OnSelectPaymentType.emit('Cash On Delivery');
    }
  }

  OnCreditInfoChanged(){
    this.OnCreditInfo.emit(new Credit(this.cardName , this.cardNumber , this.month , this.year));
  }
}
