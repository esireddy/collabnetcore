import { Component, OnInit, Injector } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { startWith, debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';
import { IGetUser } from '../../user/models/i-get-user';
import { IGetChit } from '../models/i-get-chit';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorInfo } from '../../500/error-info';
import { UserService } from '../../user/services/user.service';
import { ChitService } from '../services/chit.service';
import { ChitEditComponent } from '../chit-edit/chit-edit.component';

@Component({
  selector: 'app-chit-edit-manager',
  templateUrl: './chit-edit-manager.component.html',
  styleUrls: ['./chit-edit-manager.component.scss']
})
export class ChitEditManagerComponent implements OnInit {
  title = 'Add a Manager';
  managerForm: FormGroup;
  managerControl = new FormControl();
  managers: Observable<IGetUser[]>;
  selectedManagers: IGetUser[] = [];

  chit: IGetChit;
  parentComponent: ChitEditComponent;
  jsonPatchDoc: any = [];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private userService: UserService,
    private chitService: ChitService,
    private injector: Injector,
    private router: Router) {

    this.managerForm = this.fb.group({
      managers: []
    });

    this.parentComponent = this.injector.get(ChitEditComponent);
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
      .subscribe((data: IGetChit) => {
        this.chit = data['chitDetails'];
        console.clear();
        console.log('Cleared Console');
        console.log(this.chit);
      },
        (err: ErrorInfo) => { console.log(err); });

    if (this.chit.managerId !== 0) {
      this.title = 'Change Manager';
      this.selectedManagers.push(this.chit.manager);
      this.createManagerForm();
    }
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

      // assign managerid to chit managerid
      this.chit.managerId = manager.id;

      // rebuild form
      this.createManagerForm();

      // clear the search input and required validation
      this.managerControl.patchValue('');
      this.managerControl.clearValidators();
      this.managerControl.updateValueAndValidity();
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

    // clear managerid from chit when no manager selected
    this.chit.managerId = 0;

    // rebuild form using remaining users from selectedUsers
    this.createManagerForm();

    // add required validation when no manager selected
    this.managerControl.setValidators(Validators.required);
    this.managerControl.updateValueAndValidity();
  }

  onSaveManager(): void {
    if (this.selectedManagers.length === 1) {
      this.makePatchData();

      this.chitService
        .updateChit(
          this.chit.id,
          this.jsonPatchDoc)
        .subscribe();

      setTimeout(() => {
        this.parentComponent.reset();

        if (this.chit.noOfUsers !== this.chit.chitUsers.length) {
          this.router.navigate(['/chits', this.chit.id, 'edit', 'users']);
        } else {
          this.router.navigate(['/chits']);
        }
      }, 1000);
    }
  }

  makePatchData(): void {
    this.jsonPatchDoc.push({ 'op': 'replace', 'path': '/managerId', 'value': this.chit.managerId });
  }
}
