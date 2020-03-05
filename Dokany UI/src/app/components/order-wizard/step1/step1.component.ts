import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ShippingAddress } from 'src/app/Models/Order-Wizard/ShippingAddress';
import { FormGroup, FormControl } from '@angular/forms';
import { ShippingAddressService } from 'src/app/services/Order-Wizard/Shipping-Address/shipping-address.service';

@Component({
  selector: 'order-step1',
  templateUrl: './step1.component.html',
  styleUrls: ['./step1.component.css']
})
export class Step1Component implements OnInit {

  @Output() OnSelectedShippingAddress: EventEmitter<ShippingAddress> = new EventEmitter<ShippingAddress>();
  constructor(private shippingAddressService: ShippingAddressService) { }
  IsSelected: boolean = true;

  ShppingAddresses: ShippingAddress[] = [];
  IsAddingNewAddress: boolean = false;

  registerShippingAddress = new FormGroup({
    firstName: new FormControl(),
    lastName: new FormControl(),
    addressLine1: new FormControl(),
    addressLine2: new FormControl(),
    zipCode: new FormControl(),
    city: new FormControl(),
    country: new FormControl(-1),
    state: new FormControl(),
    phone: new FormControl(),
    useAsShippingAddress: new FormControl(true)
  });

  ngOnInit() {
    this.shippingAddressService.GetAll().subscribe(data => {
      this.ShppingAddresses = data;
    });
  }

  OnSelectAddress(Id) {
    this.OnSelectedShippingAddress.emit(this.ShppingAddresses.find(sh => sh.id == Id));
    let ids = this.ShppingAddresses.map(sh => sh.id);
    ids.forEach(id => {
      document.getElementById('addressCard' + id).style.border = "2px solid gray";
    })
    document.getElementById('addressCard' + Id).style.border = "2px solid red";
  }

  OnAddNewShippingAddress() {
    this.IsAddingNewAddress = true;
    this.registerShippingAddress = new FormGroup({
      firstName: new FormControl(this.registerShippingAddress.value.firstName),
      lastName: new FormControl(this.registerShippingAddress.value.lastName),
      addressLine1: new FormControl(this.registerShippingAddress.value.addressLine1),
      addressLine2: new FormControl(this.registerShippingAddress.value.addressLine2),
      zipCode: new FormControl(this.registerShippingAddress.value.zipCode),
      city: new FormControl(this.registerShippingAddress.value.city),
      country: new FormControl(this.registerShippingAddress.value.country),
      state: new FormControl(this.registerShippingAddress.value.state),
      phone: new FormControl(this.registerShippingAddress.value.phone),
      useAsShippingAddress: new FormControl(true)
    });
  }
  OnUseNewShippingAddress() {
    if (!this.registerShippingAddress.value.useAsShippingAddress) {
      this.IsAddingNewAddress = false;
    }
    else {
      let shippingAddress = new ShippingAddress(0,
        this.registerShippingAddress.value.firstName,
        this.registerShippingAddress.value.lastName,
        this.registerShippingAddress.value.phone,
        this.registerShippingAddress.value.addressLine1,
        this.registerShippingAddress.value.addressLine2);
        
      this.OnSelectedShippingAddress.emit(shippingAddress);
    }
  }
}
