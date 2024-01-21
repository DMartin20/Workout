import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { Subscription } from 'rxjs';
import { LoginRequest } from 'src/app/models/userLoginModel';
import { AuthenticateService } from 'src/app/services/authenticate.service';
import fromValidators from 'src/app/services/formValidators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit, OnDestroy {

  loginForm!: FormGroup;
  model: LoginRequest;
  private subscribtion?: Subscription;

  constructor(
    private fb: FormBuilder,
    private authencticate: AuthenticateService,
    private toast: NgToastService,
    private router: Router
  ) {
    this.model = {
      email: '',
      password: ''
    };
  }
  ngOnDestroy(): void {
    this.subscribtion?.unsubscribe();
  }


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onSubmit() {
    if (this.loginForm.valid) {

      this.authencticate.loginUser(this.model)
        .subscribe({
          next: (response) => {
            this.loginForm.reset();
            this.toast.success({ detail: "Sikeres Bejelentkezés!", position: 'topCenter' });
            this.router.navigate(['/frontpage']);
          },
          error: (err) => {
            this.toast.error({
              detail: err.error.message
            });
          }
        })

    } else {
      fromValidators.validateAllFormFields(this.loginForm);
      this.toast.error({
        detail: 'Invalid form!'
      });
    }
    this.loginForm.markAllAsTouched();
  }

}
