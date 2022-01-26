import { TestBed, inject } from '@angular/core/testing';

import { TaskTrackerService } from './task-tracker-service.service';

describe('TaskTrackerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TaskTrackerService]
    });
  });

  it('should be created', inject([TaskTrackerService], (service: TaskTrackerService) => {
    expect(service).toBeTruthy();
  }));
});
