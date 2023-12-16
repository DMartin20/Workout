import { BreakpointObserver } from '@angular/cdk/layout';
import { StepperOrientation } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, map } from 'rxjs';
import { AuthenticateService } from 'src/app/services/authenticate.service';
import fromValidators from 'src/app/services/formValidators';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.sass']
})

export class StepperComponent implements OnInit {

  stepperOrientation: Observable<StepperOrientation>;

  constructor(private fb: FormBuilder,
    breakpointObserver: BreakpointObserver,
    private authencticate: AuthenticateService
  ) {
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({ matches }) => (matches ? 'horizontal' : 'vertical')));
  }

  isLinear = true;

  ngOnInit(): void {

  }

  userForm = this.fb.group({
    name: this.fb.group({
      firstname: this.fb.control('', Validators.required),
      lastname: this.fb.control('', Validators.required),
    }),

    userinfo: this.fb.group({
      username: this.fb.control('', Validators.required),
      email: this.fb.control('', Validators.required),
    }),

    password: this.fb.group({
      password: this.fb.control('', Validators.required),
      password2: this.fb.control('', Validators.required),
    }),
  });

  get nameForm() {
    return this.userForm.get('name') as FormGroup;
  }
  get userinfoForm() {
    return this.userForm.get('userinfo') as FormGroup;
  }
  get passwordForm() {
    return this.userForm.get('password') as FormGroup;
  }


  OnSubmit() {
    if (this.userForm.valid) {
      console.log(this.userForm.value)
      this.authencticate.registerUser(this.userForm.value)
      .subscribe({
        next:(response)=>{
          alert(response.message)
        },
        error:(err)=>{
          alert(err.error.message)
        }
      })

    } else {
      console.log("Invalid form");

      fromValidators.validateAllFormFields(this.userForm);
      alert("Invalid form");
    }

    this.userForm.markAllAsTouched();
  }

}
