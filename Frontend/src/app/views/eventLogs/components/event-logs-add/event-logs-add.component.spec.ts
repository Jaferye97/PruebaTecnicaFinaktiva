import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventLogsAddComponent } from './event-logs-add.component';

describe('EventLogsAddComponent', () => {
  let component: EventLogsAddComponent;
  let fixture: ComponentFixture<EventLogsAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EventLogsAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EventLogsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
