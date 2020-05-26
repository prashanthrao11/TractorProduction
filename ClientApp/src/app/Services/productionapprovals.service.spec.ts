import { TestBed } from '@angular/core/testing';

import { ProductionapprovalsService } from './productionapprovals.service';

describe('ProductionapprovalsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductionapprovalsService = TestBed.get(ProductionapprovalsService);
    expect(service).toBeTruthy();
  });
});
