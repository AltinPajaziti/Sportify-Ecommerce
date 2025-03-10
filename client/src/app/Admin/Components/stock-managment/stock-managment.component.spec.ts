import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockManagmentComponent } from './stock-managment.component';

describe('StockManagmentComponent', () => {
  let component: StockManagmentComponent;
  let fixture: ComponentFixture<StockManagmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StockManagmentComponent]
    });
    fixture = TestBed.createComponent(StockManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
