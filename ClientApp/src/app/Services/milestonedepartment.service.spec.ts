import { TestBed } from '@angular/core/testing';

import { MilestonedepartmentService } from './milestonedepartment.service';

describe('MilestonedepartmentService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MilestonedepartmentService = TestBed.get(MilestonedepartmentService);
    expect(service).toBeTruthy();
  });
});
