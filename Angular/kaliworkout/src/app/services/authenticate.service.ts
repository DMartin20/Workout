import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/userLoginModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {

  private baseUrl: string = "https://localhost:7222/api/User/";
  constructor(private http: HttpClient) { }


  registerUser(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}register`, userObj);
  }

  loginUser(model: LoginRequest): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}authenticate`, model);
  }
}
