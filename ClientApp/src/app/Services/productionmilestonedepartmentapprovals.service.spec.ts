import { TestBed } from '@angular/core/testing';

import { ProductionmilestonedepartmentapprovalsService } from './productionmilestonedepartmentapprovals.service';

describe('ProductionmilestonedepartmentapprovalsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductionmilestonedepartmentapprovalsService = TestBed.get(ProductionmilestonedepartmentapprovalsService);
    expect(service).toBeTruthy();
  });
});
