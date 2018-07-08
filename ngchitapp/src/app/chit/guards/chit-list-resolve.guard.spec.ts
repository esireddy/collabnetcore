import { TestBed, async, inject } from '@angular/core/testing';

import { ChitListResolveGuard } from './chit-list-resolve.guard';

describe('ChitListResolveGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChitListResolveGuard]
    });
  });

  it('should ...', inject([ChitListResolveGuard], (guard: ChitListResolveGuard) => {
    expect(guard).toBeTruthy();
  }));
});
