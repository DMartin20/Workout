import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {

  private baseUrl: string = "https://localhost:7222/api/User/";
  constructor(private http: HttpClient) { }


  registerUser(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}register`, userObj);
  }

  loginUser(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}authenticate`, userObj);
  }
}
