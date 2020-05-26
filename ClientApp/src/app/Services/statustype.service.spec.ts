import { TestBed } from '@angular/core/testing';

import { StatustypeService } from './statustype.service';

describe('StatustypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StatustypeService = TestBed.get(StatustypeService);
    expect(service).toBeTruthy();
  });
});
