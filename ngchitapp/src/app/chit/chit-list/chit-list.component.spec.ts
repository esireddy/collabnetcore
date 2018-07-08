import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChitListComponent } from './chit-list.component';

describe('ChitListComponent', () => {
  let component: ChitListComponent;
  let fixture: ComponentFixture<ChitListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChitListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChitListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
