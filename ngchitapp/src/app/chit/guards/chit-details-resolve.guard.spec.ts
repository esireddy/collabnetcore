import { TestBed, async, inject } from '@angular/core/testing';

import { ChitDetailsResolveGuard } from './chit-details-resolve.guard';

describe('ChitDetailsResolveGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChitDetailsResolveGuard]
    });
  });

  it('should ...', inject([ChitDetailsResolveGuard], (guard: ChitDetailsResolveGuard) => {
    expect(guard).toBeTruthy();
  }));
});
