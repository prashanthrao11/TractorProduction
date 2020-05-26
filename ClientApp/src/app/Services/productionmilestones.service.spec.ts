import { TestBed } from '@angular/core/testing';

import { ProductionmilestonesService } from './productionmilestones.service';

describe('ProductionmilestonesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductionmilestonesService = TestBed.get(ProductionmilestonesService);
    expect(service).toBeTruthy();
  });
});
