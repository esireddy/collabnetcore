import { Component, OnInit, ViewChild } from '@angular/core';
import { ChitService } from '../services/chit.service';
import { IGetChit } from '../dtos/i-get-chit';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';


@Component({
  selector: 'app-list-chit',
  templateUrl: './list-chit.component.html',
  styleUrls: ['./list-chit.component.scss']
})
export class ListChitComponent implements OnInit {

  dataSource = new MatTableDataSource();

  columnsToDisplay = ['name', 'value', 'noOfMonths', 'noOfUsers', 'createDate', 'statusText', 'startDate', 'endDate'];

  chits: IGetChit[] = [];

  constructor(private chitService: ChitService) { }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

    this.dataSource.filterPredicate = (
      chit: IGetChit,
      filter: string) => (chit.name.toLocaleLowerCase().indexOf(filter) !== -1);

    this.getChits();
  }

  getChits(): void {
    this.chitService
      .getChits()
      .subscribe((data: IGetChit[]) => { this.dataSource.data = data; this.chits = data; });
  }

  filterByName(searchText: string) {
    searchText = searchText.trim();
    searchText = searchText.toLocaleLowerCase();
    this.dataSource.filter = searchText;
  }

  filterByValue(searchText: string) {
    console.log(searchText);
    searchText = searchText.trim();
    if (!searchText) {
      this.dataSource.data = this.chits;
      return;
    }

    this.dataSource.data = this.chits.filter(
      (chit: IGetChit) => chit.value.toString() === searchText);
  }
}
