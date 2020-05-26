import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewproductionrequestComponent } from './newproductionrequest.component';

describe('NewproductionrequestComponent', () => {
  let component: NewproductionrequestComponent;
  let fixture: ComponentFixture<NewproductionrequestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewproductionrequestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewproductionrequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
