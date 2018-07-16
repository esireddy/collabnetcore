import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChitStartComponent } from './chit-start.component';

describe('ChitStartComponent', () => {
  let component: ChitStartComponent;
  let fixture: ComponentFixture<ChitStartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChitStartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChitStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
