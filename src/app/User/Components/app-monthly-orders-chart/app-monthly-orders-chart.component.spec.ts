import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppMonthlyOrdersChartComponent } from './app-monthly-orders-chart.component';

describe('AppMonthlyOrdersChartComponent', () => {
  let component: AppMonthlyOrdersChartComponent;
  let fixture: ComponentFixture<AppMonthlyOrdersChartComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AppMonthlyOrdersChartComponent]
    });
    fixture = TestBed.createComponent(AppMonthlyOrdersChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
