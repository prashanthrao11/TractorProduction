import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductioncardComponent } from './productioncard.component';

describe('ProductioncardComponent', () => {
  let component: ProductioncardComponent;
  let fixture: ComponentFixture<ProductioncardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductioncardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductioncardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
