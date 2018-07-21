import { TestBed, async, inject } from '@angular/core/testing';

import { ChitEditGuardGuard } from './chit-edit-guard.guard';

describe('ChitEditGuardGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChitEditGuardGuard]
    });
  });

  it('should ...', inject([ChitEditGuardGuard], (guard: ChitEditGuardGuard) => {
    expect(guard).toBeTruthy();
  }));
});
