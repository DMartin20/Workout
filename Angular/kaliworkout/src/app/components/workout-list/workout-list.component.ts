import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkoutServiceService } from 'src/app/services/workout-service.service';

@Component({
  selector: 'app-workout-list',
  templateUrl: './workout-list.component.html',
  styleUrls: ['./workout-list.component.sass']
})
export class WorkoutListComponent implements OnInit {
  workoutList: any[] = [];
  isListRoute: boolean = false;

  constructor(private router: Router, private workoutService: WorkoutServiceService) {}

  ngOnInit() {
    this.isListRoute = this.router.url === '/workout-list';
    this.fetchWorkouts(); 
  }

  fetchWorkouts(): void {
    this.workoutService.getAllUserPlans().subscribe(
      (data) => {
        this.workoutList = data;
      },
      (error) => {
        console.log('Error fetching workouts:', error);
      }
    );
  }

  editWorkout(id: number): void {
    this.router.navigate(['/workout-edit', id]);
  }
}
