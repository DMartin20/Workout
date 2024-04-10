import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-workout-list',
  templateUrl: './workout-list.component.html',
  styleUrls: ['./workout-list.component.sass']
})
export class WorkoutListComponent {
  items: string[] = [];
  isListRoute: boolean = false;

  constructor(private router: Router) {}

  ngOnInit() {
    this.isListRoute = this.router.url === '/workout-list'; 
  }

  addItem() {
    this.items.push('New Item');
  }
}
