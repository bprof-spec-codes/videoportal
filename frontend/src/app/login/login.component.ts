import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { LoginModel } from '../models/loginmodel';
import { TokenModel } from '../models/tokenmodel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  router: Router
  http: HttpClient
  email: FormControl
  snackBar: MatSnackBar
  loginModel: LoginModel

  constructor(http:HttpClient, snackBar: MatSnackBar, router: Router){
    this.snackBar = snackBar
    this.http = http
    this.router = router
    this.email = new FormControl('',[Validators.required, Validators.email])
    this.loginModel = new LoginModel()
  }

  public showPassword = false;

  public getEmailErrorMessage() : string{
    if (this.email.hasError('required')) {
      return 'You must enter a value!';
    }
    return this.email.hasError('email') ? 'Not a valid email!' : '';
  }

  public checkInputs() : boolean {
    return this.loginModel.email !== '' && this.loginModel.password !== ''
  }

  public login(): void {
    this.http.post<TokenModel>("https://localhost:5001/api/Identity/login", this.loginModel)
    .subscribe(
      (success) => {
          localStorage.setItem('token', success.token)
          localStorage.setItem('token-expiration', success.expiration.toString())
          console.log(success)
          this.router.navigate(['/playlists'])
        },
      (error) => {
        this.snackBar
        .open("An error has occurred, please try again..", "Close", {duration: 5000})
      })
  }

  public togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }
}
