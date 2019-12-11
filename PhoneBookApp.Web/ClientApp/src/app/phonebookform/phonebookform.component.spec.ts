import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhonebookformComponent } from './phonebookform.component';

describe('PhoneBookformComponent', () => {
  let component: PhonebookformComponent;
  let fixture: ComponentFixture<PhonebookformComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhonebookformComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhonebookformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
