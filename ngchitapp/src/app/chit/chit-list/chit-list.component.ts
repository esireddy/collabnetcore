import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { ChitService } from '../services/chit.service';
import { IGetChit } from '../models/i-get-chit';
import { ErrorInfo } from '../../500/error-info';

@Component({
  selector: 'app-chit-list',
  templateUrl: './chit-list.component.html',
  styleUrls: ['./chit-list.component.scss']
})
export class ChitListComponent implements OnInit {

  dataSource = new MatTableDataSource();

  columsToDisplay = ['name', 'value', 'noOfMonths', 'noOfUsers', 'statusText', 'createDate', 'startDate', 'endDate'];

  chits$: IGetChit[];

  constructor(private chitService: ChitService) { }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() {
    this.getChits();
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  getChits(): void {
    this.chitService
      .getChits()
      .subscribe(
        (data: IGetChit[]) => { this.chits$ = data; this.dataSource.data = data; console.log(data); },
        (err: ErrorInfo) => { console.log(err); });
  }

}
