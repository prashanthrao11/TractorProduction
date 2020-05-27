import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalApproversTrackerComponent } from './final-approvers-tracker.component';

describe('FinalApproversTrackerComponent', () => {
  let component: FinalApproversTrackerComponent;
  let fixture: ComponentFixture<FinalApproversTrackerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinalApproversTrackerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinalApproversTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
