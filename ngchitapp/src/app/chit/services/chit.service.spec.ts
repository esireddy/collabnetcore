import { TestBed, inject } from '@angular/core/testing';

import { ChitService } from './chit.service';

describe('ChitService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChitService]
    });
  });

  it('should be created', inject([ChitService], (service: ChitService) => {
    expect(service).toBeTruthy();
  }));
});
