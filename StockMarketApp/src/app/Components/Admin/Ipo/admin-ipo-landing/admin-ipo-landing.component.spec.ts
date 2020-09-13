import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminIpoLandingComponent } from './admin-ipo-landing.component';

describe('AdminIpoLandingComponent', () => {
  let component: AdminIpoLandingComponent;
  let fixture: ComponentFixture<AdminIpoLandingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminIpoLandingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminIpoLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
