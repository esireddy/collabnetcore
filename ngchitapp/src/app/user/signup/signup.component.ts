import { Component, OnInit } from '@angular/core';
import { SignupUser } from '../models/signup-user';
import { NgForm } from '@angular/forms';
import { UserService } from '../services/user.service';
import { IGetUser } from '../models/i-get-user';
import { ErrorInfo } from '../../500/error-info';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  model = new SignupUser();

  isUserCreated = false;

  constructor(private userService: UserService,
    private titlecasePipe: TitleCasePipe) { }

  ngOnInit() {
  }

  onSubmit(signupForm: NgForm): void {
    if (signupForm.valid) {
      this.userService
        .createUser(this.model)
        .subscribe(
          (data: IGetUser) => {
            console.log(data);
            this.isUserCreated = true;
            setTimeout(() => {
              this.isUserCreated = false;
              signupForm.resetForm();
            }, 2000);
          },
          (err: ErrorInfo) => { console.log(err); });
    }
  }

  refresh(): void {
    window.location.reload();
  }

  capitalize(event: any): void {
    if (event.target.name === 'firstname') {
      this.model.firstname = this.titlecasePipe.transform(this.model.firstname);
    }
    if (event.target.name === 'mInitial') {
      this.model.mInitial = this.titlecasePipe.transform(this.model.mInitial);
    }
    if (event.target.name === 'lastname') {
      this.model.lastname = this.titlecasePipe.transform(this.model.lastname);
    }
  }
}
