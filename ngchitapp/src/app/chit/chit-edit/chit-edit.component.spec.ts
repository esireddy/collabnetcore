import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChitEditComponent } from './chit-edit.component';

describe('ChitEditComponent', () => {
  let component: ChitEditComponent;
  let fixture: ComponentFixture<ChitEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChitEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChitEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
