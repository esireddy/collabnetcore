import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChitEditDefaultComponent } from './chit-edit-default.component';

describe('ChitEditDefaultComponent', () => {
  let component: ChitEditDefaultComponent;
  let fixture: ComponentFixture<ChitEditDefaultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChitEditDefaultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChitEditDefaultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
