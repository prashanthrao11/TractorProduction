import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageWorkflowComponent } from './manage-workflow.component';

describe('ManageWorkflowComponent', () => {
  let component: ManageWorkflowComponent;
  let fixture: ComponentFixture<ManageWorkflowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageWorkflowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageWorkflowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
