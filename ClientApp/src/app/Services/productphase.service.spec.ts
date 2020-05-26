import { TestBed } from '@angular/core/testing';

import { ProductphaseService } from './productphase.service';

describe('ProductphaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductphaseService = TestBed.get(ProductphaseService);
    expect(service).toBeTruthy();
  });
});
