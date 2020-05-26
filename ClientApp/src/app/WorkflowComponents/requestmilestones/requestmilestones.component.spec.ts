import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestmilestonesComponent } from './requestmilestones.component';

describe('RequestmilestonesComponent', () => {
  let component: RequestmilestonesComponent;
  let fixture: ComponentFixture<RequestmilestonesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestmilestonesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestmilestonesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
