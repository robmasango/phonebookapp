import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneBooklistComponent } from './phonebooklist.component';

describe('PhoneBooklistComponent', () => {
  let component: PhoneBooklistComponent;
  let fixture: ComponentFixture<PhoneBooklistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhoneBooklistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhoneBooklistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
