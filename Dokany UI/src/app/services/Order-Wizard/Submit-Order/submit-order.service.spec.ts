import { TestBed } from '@angular/core/testing';

import { SubmitOrderService } from './submit-order.service';

describe('SubmitOrderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SubmitOrderService = TestBed.get(SubmitOrderService);
    expect(service).toBeTruthy();
  });
});
