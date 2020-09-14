import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminIpoAddComponent } from './admin-ipo-add.component';

describe('AdminIpoAddComponent', () => {
  let component: AdminIpoAddComponent;
  let fixture: ComponentFixture<AdminIpoAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminIpoAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminIpoAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
