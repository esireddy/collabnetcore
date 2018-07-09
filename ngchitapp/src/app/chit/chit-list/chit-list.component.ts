import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { IGetChit } from '../models/i-get-chit';
import { ErrorInfo } from '../../500/error-info';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chit-list',
  templateUrl: './chit-list.component.html',
  styleUrls: ['./chit-list.component.scss']
})
export class ChitListComponent implements OnInit {

  dataSource = new MatTableDataSource();

  columsToDisplay = ['name', 'value', 'noOfMonths', 'noOfUsers', 'statusText', 'createDate'];

  chits$: IGetChit[];

  constructor(private route: ActivatedRoute) { }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() {
    this.getChits();
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  getChits(): void {
    this.route
      .data
      .subscribe((data: IGetChit[]) => {
        this.chits$ = data['chitlist'];
        this.dataSource.data = data['chitlist'];
      },
        (err: ErrorInfo) => { console.log(err); });
  }

}
