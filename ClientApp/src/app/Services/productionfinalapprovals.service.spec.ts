import { TestBed } from '@angular/core/testing';

import { ProductionfinalapprovalsService } from './productionfinalapprovals.service';

describe('ProductionfinalapprovalsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductionfinalapprovalsService = TestBed.get(ProductionfinalapprovalsService);
    expect(service).toBeTruthy();
  });
});
