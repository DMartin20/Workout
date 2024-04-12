import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticateService } from './AuthenticateService';
import { CreateWorkoutDTO } from '../models/createWorkoutDTO';
import { Exercise } from '../models/exercise';
import { WorkoutPlan } from '../models/workoutPlan';
import { UpdatePlan } from '../models/updatePlan';

@Injectable({
  providedIn: 'root'
})
export class WorkoutServiceService {

  private basePlanUrl: string = "https://localhost:7222/api/WorkoutPlan/";
  private baseExerciseUrl: string = "https://localhost:7222/api/Exercise/";
  constructor(private http: HttpClient, private authService: AuthenticateService) { }

  getAllUserPlans(): Observable<any[]> {
    const userId = this.authService.getUserId();
    return this.http.get<any[]>(`${this.basePlanUrl}getUsersPlans/${userId}`);
  }

  createWorkoutPlan(plan: CreateWorkoutDTO): Observable<any> {
    const userId = this.authService.getUserId();
    return this.http.post<any>(`${this.basePlanUrl}CreatePlan/${userId}`, plan)
  }

  getAllExercises(): Observable<Exercise[]> {
    return this.http.get<any[]>(`${this.baseExerciseUrl}getAllExercise`);
  }

  getPlanById(id: number): Observable<WorkoutPlan> {
    return this.http.get<any>(`${this.basePlanUrl}getPlanById/${id}`);
  }

  updateWorkoutPlan(id: number, newplan: UpdatePlan): Observable<any> {
    return this.http.post<any>(`${this.basePlanUrl}updateWorkoutPlan/${id}`, newplan)
  }
}
