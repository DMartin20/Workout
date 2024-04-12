import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { WorkoutServiceService } from 'src/app/services/workout-service.service';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Exercise } from 'src/app/models/exercise';
import { WorkoutPlan } from 'src/app/models/workoutPlan';
import { UpdatePlan } from 'src/app/models/updatePlan';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-edit-workoutplan',
  templateUrl: './edit-workoutplan.component.html',
  styleUrls: ['./edit-workoutplan.component.sass']
})
export class EditWorkoutplanComponent implements OnInit {
  isListRoute: boolean = false;
  loadedWorkout?: WorkoutPlan;
  exercisesInPlan: Exercise[] = [];
  availableExercises: Exercise[] = [];
  updatedPlan: UpdatePlan = { workoutName: '', rest: 0, reps: 0, exerciseIds: [], counts: [] };

  constructor(private router: Router, private workoutService: WorkoutServiceService, private route: ActivatedRoute, private toast: NgToastService) {
  }


  ngOnInit(): void {
    this.isListRoute = this.router.url.includes('/workout-edit');

    const workoutId = this.route.snapshot.params['id'];

    this.workoutService.getPlanById(workoutId).subscribe(
      (workout: WorkoutPlan) => {
        this.loadedWorkout = workout;
        this.exercisesInPlan = workout.exercises;
        // Ensure that loadedWorkout?.exercises is initialized as an empty array if it's undefined
      },
      (error) => {
        console.log('Error fetching workout:', error);
      }
    );



    this.workoutService.getAllExercises()
      .subscribe((exercises: Exercise[]) => {
        this.availableExercises = exercises;
      });
  }

  drop(event: CdkDragDrop<Exercise[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      const clonedItem = { ...event.previousContainer.data[event.previousIndex] }; // Klónozzuk az elemet
      transferArrayItem([clonedItem], event.container.data, 0, event.currentIndex); // Adjuk hozzá a klónozott elemet a baloldali sávhoz
    }
  }

  saveButton() {
    const workoutId = this.route.snapshot.params['id'];
    // Frissítjük az updatedPlan objektumot az új terv adataival
    if (this.loadedWorkout) {
      this.updatedPlan.workoutName = this.loadedWorkout.workoutName;
      this.updatedPlan.rest = this.loadedWorkout.rest;
      this.updatedPlan.exerciseIds = this.exercisesInPlan.map(exercise => exercise.id);
      this.updatedPlan.reps = this.loadedWorkout.reps;
      this.fillCounts();
    }

    console.log(this.updatedPlan);

    this.workoutService.updateWorkoutPlan(workoutId, this.updatedPlan).subscribe(
      (response) => {

        this.toast.success({ detail: response.message, position: 'topCenter' });
        
        this.router.navigate(['/workout-list']);
      },
      (error) => {
        console.error('Error updating plan', error);
      }
    );

  }

  fillCounts() {
    if (this.exercisesInPlan.length > 0) {
      this.updatedPlan.counts = Array(this.exercisesInPlan.length).fill(1);
    }

  }

}
