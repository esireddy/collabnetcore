import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListChitComponent } from './list-chit.component';

describe('ListChitComponent', () => {
  let component: ListChitComponent;
  let fixture: ComponentFixture<ListChitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListChitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListChitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
