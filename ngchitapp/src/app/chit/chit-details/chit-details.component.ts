import { Component, OnInit } from '@angular/core';
import { IGetChit } from '../models/i-get-chit';
import { ActivatedRoute } from '@angular/router';
import { ErrorInfo } from '../../500/error-info';
import { FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { startWith, debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';
import { UserService } from '../../user/services/user.service';
import { IGetUser } from '../../user/models/i-get-user';

@Component({
  selector: 'app-chit-details',
  templateUrl: './chit-details.component.html',
  styleUrls: ['./chit-details.component.scss']
})
export class ChitDetailsComponent implements OnInit {

  chit: IGetChit;

  // user section
  usersForm: FormGroup;
  userControl = new FormControl();
  users: Observable<IGetUser[]>;
  selectedUsers: IGetUser[] = [];
  disableSaveUsers = true;


  commission: number;
  auctionDate: number;


  constructor(private route: ActivatedRoute,
    private userService: UserService,
    private fb: FormBuilder) {
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
      .data
      .subscribe((data: IGetChit) => { this.chit = data['chitDetails']; },
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
      this.disableSaveUsers = false;
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
        index: (i - 1) + 1,
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
