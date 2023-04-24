import { Component } from '@angular/core';
import {RegisterData} from "./signup.type";
import {FormControl, Validators} from "@angular/forms";
import {MyErrorStateMatcher} from "../utils/MyErrorStateMatcher";
import {SignupService} from "../../services/signup.service";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {
  constructor(private signupService: SignupService) {}

  public showPassword = false;

  registerData: RegisterData = {
    fullName: '',
    userName: '',
    email: '',
    password: '',
    confirmPassword: '',
    readConsent: false,
    errors: [],
  }

  fullNameControl = new FormControl('', [Validators.required]);
  usernameControl = new FormControl('', [Validators.required]);
  emailControl = new FormControl('', [Validators.required, Validators.email]);
  passwordControl = new FormControl('', [Validators.required, Validators.minLength(8)]);
  confirmPasswordControl = new FormControl('', [Validators.required, Validators.minLength(8)]);

  matcher = new MyErrorStateMatcher();

  getErrorMessage(param: string) {
    if (param === 'fullName') {
      return 'You must enter a full name to continue the registration process!';
    }

    if (param === 'userName') {
      return 'You must enter a user name to continue the registration process!';
    }

    if (param === 'email') {
      if (this.emailControl.hasError('email')) {
        return 'You must enter a valid email address to continue the registration process!';
      }

      return 'You must enter a user name email address to continue the registration process!';
    }

    if (param === 'password') {
      return 'You must enter a password to continue the registration process!';
    }

    if (param === 'passwordConfirmation') {
      return 'You must enter a password confirmation to continue the registration process!';
    }

    return '';
  }

  public togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }

  public register(): void {
    this.signupService.register(this.registerData);
  }
}
