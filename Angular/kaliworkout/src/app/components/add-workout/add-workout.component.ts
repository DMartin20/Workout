import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { CreateWorkoutDTO } from 'src/app/models/createWorkoutDTO';
import { WorkoutServiceService } from 'src/app/services/workout-service.service';

@Component({
  selector: 'app-add-workout',
  templateUrl: './add-workout.component.html',
  styleUrls: ['./add-workout.component.sass']
})
export class AddWorkoutComponent implements OnInit {
  isListRoute: boolean = false;

  newWorkout: CreateWorkoutDTO =  {
    workoutName: '',
    rest: 0,
    reps: 0
  }
  
  constructor(private router: Router, private workoutService: WorkoutServiceService, private toast: NgToastService) {}

  ngOnInit(): void {
    this.isListRoute = this.router.url === '/add-workout';
  }

  addWorkout(): void {
    this.workoutService.createWorkoutPlan(this.newWorkout).subscribe(
      (response) => {
        this.toast.success({ detail: "Edzésterv Létrehozva!", position: 'topCenter' });
        this.router.navigate(['/workout-list']);
      },
      (error) => {
        console.error('Error creating new workout plan:', error);
        // Handle error, if needed
      }
    );
  }

}
