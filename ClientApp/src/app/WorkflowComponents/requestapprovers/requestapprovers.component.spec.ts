import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestapproversComponent } from './requestapprovers.component';

describe('RequestapproversComponent', () => {
  let component: RequestapproversComponent;
  let fixture: ComponentFixture<RequestapproversComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestapproversComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestapproversComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
