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

  commission: number;
  auctionDate: number;


  constructor(private route: ActivatedRoute,
    private userService: UserService,
    private fb: FormBuilder) {
  }

  ngOnInit() {
    this.getChit();
  }

  getChit(): void {
    this.route
      .data
      .subscribe((data: IGetChit) => { this.chit = data['chitDetails']; },
        (err: ErrorInfo) => { console.log(err); });
  }
}
