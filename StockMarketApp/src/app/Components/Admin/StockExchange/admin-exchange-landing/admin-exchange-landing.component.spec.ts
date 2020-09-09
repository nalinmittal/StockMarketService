import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminExchangeLandingComponent } from './admin-exchange-landing.component';

describe('AdminExchangeLandingComponent', () => {
  let component: AdminExchangeLandingComponent;
  let fixture: ComponentFixture<AdminExchangeLandingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminExchangeLandingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminExchangeLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
