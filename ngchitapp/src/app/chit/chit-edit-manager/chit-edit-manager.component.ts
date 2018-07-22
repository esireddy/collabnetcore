import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { startWith, debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';
import { IGetUser } from '../../user/models/i-get-user';
import { IGetChit } from '../models/i-get-chit';
import { ActivatedRoute } from '@angular/router';
import { ErrorInfo } from '../../500/error-info';
import { UserService } from '../../user/services/user.service';

@Component({
  selector: 'app-chit-edit-manager',
  templateUrl: './chit-edit-manager.component.html',
  styleUrls: ['./chit-edit-manager.component.scss']
})
export class ChitEditManagerComponent implements OnInit {

  managerForm: FormGroup;
  managerControl = new FormControl();
  managers: Observable<IGetUser[]>;
  selectedManagers: IGetUser[] = [];

  chit: IGetChit;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private userService: UserService) {
    this.managerForm = this.fb.group({
      managers: []
    });
  }

  ngOnInit() {
    this.getChit();

    this.managers = this.managerControl.valueChanges
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

  onSelectManager(manager: IGetUser): void {
    this.selectedManagers = [];
    if (manager) {
      this.selectedManagers.push(manager);

      // rebuild form
      this.createManagerForm();

      // clear the search input
      this.managerControl.patchValue('');
    }
  }

  displayFn(user: IGetUser): string {
    if (user) {
      const fullname = `${user.firstname} ${user.mInitial ? user.mInitial : ''} ${user.lastname}`;
      return fullname;
    }
  }

  createManagerForm(): void {
    // create formControl for each selected user
    const control = this.selectedManagers.map(
      c => new FormControl({ value: `${c.firstname} ${c.mInitial ? c.mInitial : ''} ${c.lastname}`, disabled: true })
    );

    // recreate the form
    this.managerForm = this.fb.group({
      managers: new FormArray(control)
    });
  }

  onManagerChange(): void {
    this.selectedManagers = [];

    // rebuild form using remaining users from selectedUsers
    this.createManagerForm();
  }
}
