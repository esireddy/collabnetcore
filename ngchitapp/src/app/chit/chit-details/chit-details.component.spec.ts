import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChitDetailsComponent } from './chit-details.component';

describe('ChitDetailsComponent', () => {
  let component: ChitDetailsComponent;
  let fixture: ComponentFixture<ChitDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChitDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChitDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
