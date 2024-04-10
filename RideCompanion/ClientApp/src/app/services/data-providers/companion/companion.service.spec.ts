import { TestBed } from '@angular/core/testing';

import { CompanionService } from './companion.service';

describe('CompanionService', () => {
  let service: CompanionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompanionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
