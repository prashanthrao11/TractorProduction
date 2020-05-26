import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproversTrackerComponent } from './approvers-tracker.component';

describe('ApproversTrackerComponent', () => {
  let component: ApproversTrackerComponent;
  let fixture: ComponentFixture<ApproversTrackerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApproversTrackerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApproversTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
