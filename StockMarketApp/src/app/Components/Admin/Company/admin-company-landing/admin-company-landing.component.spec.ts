import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCompanyLandingComponent } from './admin-company-landing.component';

describe('AdminCompanyLandingComponent', () => {
  let component: AdminCompanyLandingComponent;
  let fixture: ComponentFixture<AdminCompanyLandingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCompanyLandingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCompanyLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
