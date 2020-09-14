import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminExchangeViewComponent } from './admin-exchange-view.component';

describe('AdminExchangeViewComponent', () => {
  let component: AdminExchangeViewComponent;
  let fixture: ComponentFixture<AdminExchangeViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminExchangeViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminExchangeViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
