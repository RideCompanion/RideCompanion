import { TestBed } from '@angular/core/testing';

import { RideListService } from './ride-list.service';

describe('RideListServiceService', () => {
  let service: RideListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RideListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
