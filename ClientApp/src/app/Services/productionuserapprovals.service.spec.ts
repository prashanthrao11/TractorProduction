import { TestBed } from '@angular/core/testing';

import { ProductionuserapprovalsService } from './productionuserapprovals.service';

describe('ProductionuserapprovalsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductionuserapprovalsService = TestBed.get(ProductionuserapprovalsService);
    expect(service).toBeTruthy();
  });
});
