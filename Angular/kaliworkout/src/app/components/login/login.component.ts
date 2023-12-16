import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthenticateService } from 'src/app/services/authenticate.service';
import fromValidators from 'src/app/services/formValidators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authencticate: AuthenticateService,
    private toast: NgToastService,
    private router: Router
    ) { }


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onSubmit() {
    if (this.loginForm.valid) {
      
      this.authencticate.loginUser(this.loginForm.value)
      .subscribe({
        next:(response)=>{
          this.loginForm.reset();
          this.toast.success({detail:"Sikeres Bejelentkezés!", summary:response.message, duration: 5000, position:'topCenter'});
          this.router.navigate(['/frontpage']);
        },
        error:(err)=>{
          alert(err.error.message)
        }
      })

    } else {
      console.log("Invalid form");
      
      const passwordControl = this.loginForm.get('password');
      console.log('Password control:', passwordControl);
  
      fromValidators.validateAllFormFields(this.loginForm);
      alert("Invalid form");
    }
    this.loginForm.markAllAsTouched();
  }

}
