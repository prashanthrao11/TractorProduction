import { TestBed } from '@angular/core/testing';

import { DepartmentapproversService } from './departmentapprovers.service';

describe('DepartmentapproversService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DepartmentapproversService = TestBed.get(DepartmentapproversService);
    expect(service).toBeTruthy();
  });
});
