import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { startWith, debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';
import { IGetUser } from '../../user/models/i-get-user';
import { IGetChit } from '../models/i-get-chit';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../user/services/user.service';
import { ErrorInfo } from '../../500/error-info';

@Component({
  selector: 'app-chit-edit-users',
  templateUrl: './chit-edit-users.component.html',
  styleUrls: ['./chit-edit-users.component.scss']
})
export class ChitEditUsersComponent implements OnInit {

  usersForm: FormGroup;
  userControl = new FormControl();
  users: Observable<IGetUser[]>;
  selectedUsers: IGetUser[] = [];

  chit: IGetChit;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private userService: UserService) {
    this.usersForm = this.fb.group({
      users: []
    });
  }

  ngOnInit() {
    this.getChit();

    this.users = this.userControl.valueChanges
      .pipe(
        startWith(''),
        debounceTime(200),
        distinctUntilChanged(),
        switchMap(val => {
          return this.getUsers(val || '');
        })
      );
  }

  getChit(): void {
    this.route
      .parent
      .data
      .subscribe((data: IGetChit) => { this.chit = data['chitDetails']; console.log(this.chit); },
        (err: ErrorInfo) => { console.log(err); });
  }

  getUsers(val: string): Observable<IGetUser[]> {
    if (val) {
      if (typeof val === 'object') {
        return of(null);
      }

      return this.userService
        .getUsers(val)
        .pipe(
          map(response => response.filter((user: IGetUser) => {
            return user;
          }))
        );
    } else {
      return of(null);
    }
  }

  displayFn(user: IGetUser): string {
    if (user) {
      const fullname = `${user.firstname} ${user.mInitial ? user.mInitial : ''} ${user.lastname}`;
      return fullname;
    }
  }

  onSelectUser(user: IGetUser): void {
    // add user to temporary array
    if (user) {
      this.selectedUsers.push(user);
      // rebuild form
      this.createUserForm();

      // clear the search input
      this.userControl.patchValue('');
    }
  }

  createUserForm(): void {
    const index = -1;
    // create formControl for each selected user
    const controls = this.selectedUsers.map((user, i) => {
      return this.fb.group({
        index: i,
        name: `${user.firstname} ${user.mInitial ? user.mInitial : ''} ${user.lastname}`
      });
    });

    // recreate the form
    this.usersForm = this.fb.group({
      users: new FormArray(controls)
    });
  }

  onUserChange(index: number): void {
    // arg1 is where to start, arg2 is number of elements to add/remove
    this.selectedUsers.splice(index, 1);

    // rebuild form using remaining users from selectedUsers
    this.createUserForm();
  }
}
