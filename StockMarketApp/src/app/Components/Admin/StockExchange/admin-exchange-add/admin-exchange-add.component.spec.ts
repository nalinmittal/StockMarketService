import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminExchangeAddComponent } from './admin-exchange-add.component';

describe('AdminExchangeAddComponent', () => {
  let component: AdminExchangeAddComponent;
  let fixture: ComponentFixture<AdminExchangeAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminExchangeAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminExchangeAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
