import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddChitComponent } from './add-chit.component';

describe('AddChitComponent', () => {
  let component: AddChitComponent;
  let fixture: ComponentFixture<AddChitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddChitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddChitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
