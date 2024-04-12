import { Exercise } from "./exercise";

export interface WorkoutPlan {
    workoutId: number;
    workoutName: string;
    rest: number;
    reps: number;
    exercises: Exercise[];
}