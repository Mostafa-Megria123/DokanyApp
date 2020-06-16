import { Injectable } from '@angular/core';
import { Order } from 'src/app/admin/models/order-wizard/Order';

@Injectable({
  providedIn: 'root'
})
export class SubmitOrderService {

  constructor() { }

  Post(order: Order){
    console.log(order)
  }
}
