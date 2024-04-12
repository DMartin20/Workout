import { Component, inject } from '@angular/core';
import { AuthenticateService } from 'src/app/services/AuthenticateService';
import { RouteService } from 'src/app/services/routeservice.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  isSidebarOpen = false;
  isListRoute: boolean = false;
  isAddRoute: boolean = false;
  isProfileRoute: boolean = false;
  isEditRoute: boolean = false;
  isLoggedIn: boolean = false;
  username: string | undefined;
  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }
  constructor(
    private routeService: RouteService,
    private authService: AuthenticateService
  ) {

  }

  ngOnInit() {

    this.routeService.currentRoute$.subscribe(route => {
      this.isListRoute = route === '/workout-list';
      this.isProfileRoute = route === '/profile';
      this.isAddRoute = route === '/add-workout';
      this.isEditRoute = route.startsWith('/workout-edit'); // Change '/list' to the actual route of your list component
    });

    this.authService.authStatus$.subscribe(status => {
      this.isLoggedIn = status;
      if (this.isLoggedIn) {
        // Fetch username or user information here
        // For demonstration, I'll assume you have a function to get the username from AuthService
        this.username = this.authService.getUsername();
      } else {
        this.username = undefined;
      }
    });
  }

  OnSignout()
  {
    this.authService.logout();
  }
}
