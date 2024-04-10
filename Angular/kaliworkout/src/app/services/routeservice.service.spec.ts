import { TestBed } from '@angular/core/testing';

import { RouteserviceService } from './routeservice.service';

describe('RouteserviceService', () => {
  let service: RouteserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RouteserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
