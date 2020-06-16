import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ShippingAddress } from 'src/app/admin/Models/Order-Wizard/ShippingAddress';

@Injectable({
  providedIn: 'root'
})
export class ShippingAddressService {

  constructor() { }
  
  ShippingAddresss: ShippingAddress[] = [
    new ShippingAddress(1 , 'Eslam' , 'Heikal' ,'(02) 11822062','10 Fowa Street' , 'Fowa'  ),
    new ShippingAddress(2 , 'Saly' ,'Ahmed' , '(02) 12500123' , '10 Fowa Street' , 'Fowa' )
  ];

  GetAll(): Observable<ShippingAddress[]>{
    return of(this.ShippingAddresss);
  }
}
