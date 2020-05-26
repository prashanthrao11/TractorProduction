import { TestBed } from '@angular/core/testing';

import { WorkflowApproverService } from './workflow-approver.service';

describe('WorkflowApproverService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkflowApproverService = TestBed.get(WorkflowApproverService);
    expect(service).toBeTruthy();
  });
});
