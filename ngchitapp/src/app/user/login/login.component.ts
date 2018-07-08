import { Component, OnInit } from '@angular/core';
import { LoginUser } from '../models/login-user';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
// social-login-start
import { AuthService, GoogleLoginProvider } from 'angularx-social-login';
// social-login-end

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model = new LoginUser();

  constructor(private loginService: LoginService,
    private router: Router,
    private socialAuthService: AuthService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.loginService
        .login()
        .subscribe(() => {
          if (this.loginService.isLoggedIn) {
            const redirect = this.loginService.redirectUrl ? this.loginService.redirectUrl : '/home';
            this.router.navigate([redirect]);
          }
        });
    }
  }

  refresh(): void {
    window.location.reload();
  }

  public signinWithGoogle() {
    const socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;

    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        // on success
        // this will return user data from google. What you need is a user token which you will send it to the server
        // this.sendToRestApiMethod(userData.idToken);
        console.log(userData);
      }
    );
  }
}
