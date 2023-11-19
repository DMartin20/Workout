import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.sass']
})
export class StepperComponent {
  
  steps = [
    { number: 1, title: 'Step 1' },
    { number: 2, title: 'Step 2' },
    { number: 3, title: 'Step 3' },
  ];

  formGroups: FormGroup[] = [];

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.steps.forEach(() => {
      const formGroup = this.fb.group({
        inputField1: ['', Validators.required],
        inputField2: ['', Validators.required],
      });
      this.formGroups.push(formGroup);
    });
  }

  stepFormGroup(step: any): FormGroup {
    return this.formGroups[step.number - 1];
  }
}
