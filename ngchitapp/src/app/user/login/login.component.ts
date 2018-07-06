import { Component, OnInit } from '@angular/core';
import { LoginUser } from '../models/login-user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model = new LoginUser();

  constructor() { }

  ngOnInit() {
  }

  refresh(): void {
    window.location.reload();
  }
}
