import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkflowPhaseMilestoneComponent } from './workflow-phase-milestone.component';

describe('WorkflowPhaseMilestoneComponent', () => {
  let component: WorkflowPhaseMilestoneComponent;
  let fixture: ComponentFixture<WorkflowPhaseMilestoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkflowPhaseMilestoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkflowPhaseMilestoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
