import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCompanyAddComponent } from './admin-company-add.component';

describe('AdminCompanyAddComponent', () => {
  let component: AdminCompanyAddComponent;
  let fixture: ComponentFixture<AdminCompanyAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCompanyAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCompanyAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
