import { TestBed } from '@angular/core/testing';

import { ShippingAddressService } from './shipping-address.service';

describe('ShippingAddressService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ShippingAddressService = TestBed.get(ShippingAddressService);
    expect(service).toBeTruthy();
  });
});
