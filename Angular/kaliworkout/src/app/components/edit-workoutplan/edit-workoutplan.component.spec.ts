import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditWorkoutplanComponent } from './edit-workoutplan.component';

describe('EditWorkoutplanComponent', () => {
  let component: EditWorkoutplanComponent;
  let fixture: ComponentFixture<EditWorkoutplanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditWorkoutplanComponent]
    });
    fixture = TestBed.createComponent(EditWorkoutplanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
