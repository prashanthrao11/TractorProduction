import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestfinalapproversComponent } from './requestfinalapprovers.component';

describe('RequestfinalapproversComponent', () => {
  let component: RequestfinalapproversComponent;
  let fixture: ComponentFixture<RequestfinalapproversComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestfinalapproversComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestfinalapproversComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
