import { Component, OnInit } from '@angular/core';
import { SignupUser } from '../models/signup-user';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  model = new SignupUser();

  constructor() { }

  ngOnInit() {
  }

  refresh(): void {
    window.location.reload();
  }
}
