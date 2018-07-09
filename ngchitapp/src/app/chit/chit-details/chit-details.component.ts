import { Component, OnInit } from '@angular/core';
import { IGetChit } from '../models/i-get-chit';
import { ActivatedRoute } from '@angular/router';
import { ErrorInfo } from '../../500/error-info';

@Component({
  selector: 'app-chit-details',
  templateUrl: './chit-details.component.html',
  styleUrls: ['./chit-details.component.scss']
})
export class ChitDetailsComponent implements OnInit {

  chit: IGetChit;

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
}
