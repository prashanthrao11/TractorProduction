import { TestBed } from '@angular/core/testing';

import { WorkflowphasemilestonesService } from './workflowphasemilestones.service';

describe('WorkflowphasemilestonesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkflowphasemilestonesService = TestBed.get(WorkflowphasemilestonesService);
    expect(service).toBeTruthy();
  });
});
