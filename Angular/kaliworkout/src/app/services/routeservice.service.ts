import { Injectable } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RouteService {
  currentRoute$: BehaviorSubject<string>;

  constructor(private router: Router) {
    this.currentRoute$ = new BehaviorSubject<string>(this.router.url);

    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.currentRoute$.next(event.url);
      }
    });
  }
}