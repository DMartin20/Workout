import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { FrontpageComponent } from './components/frontpage/frontpage.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { WorkoutListComponent } from './components/workout-list/workout-list.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {
    path: 'login', component: LoginComponent 
  },
  {
    path: 'registration', component: RegistrationComponent
  },
  {
    path: 'frontpage', component: FrontpageComponent
  },
  {
    path: 'workout-list', component: WorkoutListComponent, canActivate: [AuthGuard]
  },
  {
    path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]
  },
  {
    path: '', redirectTo: '/frontpage', pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
