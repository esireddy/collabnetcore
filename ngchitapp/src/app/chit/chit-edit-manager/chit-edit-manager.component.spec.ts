import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChitEditManagerComponent } from './chit-edit-manager.component';

describe('ChitEditManagerComponent', () => {
  let component: ChitEditManagerComponent;
  let fixture: ComponentFixture<ChitEditManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChitEditManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChitEditManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
