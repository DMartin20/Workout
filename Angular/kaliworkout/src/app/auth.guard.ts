import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthenticateService } from './services/AuthenticateService';
import { Observable } from 'rxjs';
import { NgToastService } from 'ng-angular-popup';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthenticateService, private router: Router, private toast: NgToastService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    
    return this.authService.authStatus$.pipe(
      tap(isLoggedIn => {
        if (!isLoggedIn) {
          // If user is not logged in, redirect to front page
          this.toast.error({detail: "ERROR", summary: "Please login first!"});
          this.router.navigate(['/login']);
        }
      })
    );
  }
}
