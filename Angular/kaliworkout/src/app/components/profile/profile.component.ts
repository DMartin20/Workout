import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticateService } from 'src/app/services/AuthenticateService';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.sass']
})
export class ProfileComponent implements OnInit {
  user$!: Observable<any>; // Define an observable to hold user information

  constructor(private authService: AuthenticateService) { }

  ngOnInit(): void {
    // Fetch user information when the component initializes
    this.user$ = this.authService.getUserProfile();
  }
}
