export interface UpdatePlan {
    workoutName: string;
    rest: number;
    reps: number;
    exerciseIds: number[];
    counts: number[];
}