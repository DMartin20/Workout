import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/userLoginModel';
import { LoginResponse } from '../models/loginResponse';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {
  private isLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private username: string | undefined;
  private userid: number | undefined;
  authStatus$ = this.isLoggedIn.asObservable();

  private baseUrl: string = "https://localhost:7222/api/User/";
  constructor(private http: HttpClient, private router: Router) { }


  registerUser(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}register`, userObj)
  }

  loginUser(model: LoginRequest): Observable<LoginResponse> {
    return this.http.post<any>(`${this.baseUrl}authenticate`, model).pipe(
      tap(response => {
        if (!!localStorage.getItem('token')){
          this.isLoggedIn.next(true)
        } else {
          this.isLoggedIn.next(false)
        }

        if (response && response.userName) {
          this.username = response.userName;
          this.setUsername(this.username);
          this.userid = response.id;
          this.setUserId(this.userid);
        }

      })
    )
  }

  setUsername(username: string) {
    localStorage.setItem('username', username)
  }

  getUsername(): string | undefined {
    const username = localStorage.getItem('username')
    return username !== null ? username : undefined
  }

  setUserId(userId: number) {
    localStorage.setItem('userId', userId.toString()); // Convert to string before storing
  }

  getUserId(): number | undefined {
    const userId = localStorage.getItem('userId');
    return userId ? parseInt(userId, 10) : undefined; // Convert back to number after retrieving
  }

  getUserProfile(): Observable<any> {
    if (this.userid) {
      return this.http.get<any>(`${this.baseUrl}GetUserData/${this.userid}`)
    } else {
      return new Observable<any>()
    }
  }

  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue)
  }

  getToken() {
    return localStorage.getItem('token')
  }

  logout() {
    localStorage.clear();
    this.isLoggedIn.next(false);
    this.router.navigate(['/frontpage']);
  }
}
