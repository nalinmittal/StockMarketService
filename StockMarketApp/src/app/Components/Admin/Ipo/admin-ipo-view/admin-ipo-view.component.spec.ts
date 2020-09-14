import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminIpoViewComponent } from './admin-ipo-view.component';

describe('AdminIpoViewComponent', () => {
  let component: AdminIpoViewComponent;
  let fixture: ComponentFixture<AdminIpoViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminIpoViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminIpoViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
