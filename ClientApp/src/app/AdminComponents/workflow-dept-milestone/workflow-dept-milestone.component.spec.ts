import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkflowDeptMilestoneComponent } from './workflow-dept-milestone.component';

describe('WorkflowDeptMilestoneComponent', () => {
  let component: WorkflowDeptMilestoneComponent;
  let fixture: ComponentFixture<WorkflowDeptMilestoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkflowDeptMilestoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkflowDeptMilestoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
