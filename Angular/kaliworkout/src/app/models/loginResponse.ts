export interface LoginResponse {
    id: number;
    firstName: string;
    lastName: string;
    userName: string;
    password: string;
    token: string;
    role: string;
    email: string;
    created: string; // Assuming it's a date string in ISO format
    workoutPlans: any[] | null; // Assuming it's an array of workout plans or null
}