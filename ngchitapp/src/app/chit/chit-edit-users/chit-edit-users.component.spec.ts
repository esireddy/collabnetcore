import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChitEditUsersComponent } from './chit-edit-users.component';

describe('ChitEditUsersComponent', () => {
  let component: ChitEditUsersComponent;
  let fixture: ComponentFixture<ChitEditUsersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChitEditUsersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChitEditUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
