import { TestBed } from '@angular/core/testing';

import { IconapiService } from './iconapi.service';

describe('IconapiService', () => {
  let service: IconapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IconapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
