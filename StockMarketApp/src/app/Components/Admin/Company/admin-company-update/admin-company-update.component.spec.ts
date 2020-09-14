import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCompanyUpdateComponent } from './admin-company-update.component';

describe('AdminCompanyUpdateComponent', () => {
  let component: AdminCompanyUpdateComponent;
  let fixture: ComponentFixture<AdminCompanyUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCompanyUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCompanyUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
