import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { FrontpageComponent } from './components/frontpage/frontpage.component';

const routes: Routes = [
  {
    path: 'login', component: LoginComponent 
  },
  {
    path: 'frontpage', component: FrontpageComponent
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
