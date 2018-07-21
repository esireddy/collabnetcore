import { Component, OnInit } from '@angular/core';
import { IGetChit } from '../models/i-get-chit';
import { ActivatedRoute } from '@angular/router';
import { ErrorInfo } from '../../500/error-info';

@Component({
  selector: 'app-chit-edit',
  templateUrl: './chit-edit.component.html',
  styleUrls: ['./chit-edit.component.scss']
})
export class ChitEditComponent implements OnInit {

  currentChit: IGetChit;
  originalChit: IGetChit;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getChit();
  }

  getChit(): void {
    this.route
      .data
      .subscribe((data: IGetChit) => { this.chit = data['chitDetails']; },
        (err: ErrorInfo) => { console.log(err); });
  }

  get chit(): IGetChit {
    return this.currentChit;
  }

  set chit(value: IGetChit) {
    this.currentChit = value;
    this.originalChit = Object.assign({}, value);

  }

  get isDirty(): boolean {
    return JSON.stringify(this.currentChit) !== JSON.stringify(this.originalChit);
  }

  reset(): void {
    this.currentChit = null;
    this.originalChit = null;
  }

}
