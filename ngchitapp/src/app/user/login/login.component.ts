import { Component, OnInit } from '@angular/core';
import { LoginUser } from '../models/login-user';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model = new LoginUser();

  constructor(private loginService: LoginService,
    private router: Router) { }

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
}
