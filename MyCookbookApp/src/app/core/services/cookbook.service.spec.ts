/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CookbookService } from './cookbook.service';

describe('Service: Cookbook', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CookbookService]
    });
  });

  it('should ...', inject([CookbookService], (service: CookbookService) => {
    expect(service).toBeTruthy();
  }));
});
