import { Component, OnInit } from '@angular/core';
import { AddChit } from '../models/add-chit';
import { ChitService } from '../services/chit.service';
import { IGetChit } from '../dtos/i-get-chit';
import { ErrorInfo } from '../../error/error-info';

@Component({
  selector: 'app-add-chit',
  templateUrl: './add-chit.component.html',
  styleUrls: ['./add-chit.component.scss']
})
export class AddChitComponent implements OnInit {

  model = new AddChit('Apple', 100000, 25, 25);

  lblmsg = '';

  constructor(private chitService: ChitService) { }

  ngOnInit() {
  }

  private addChit(): void {
    this.chitService
      .addChit(this.model)
      .subscribe(
        (data: IGetChit) => { this.lblmsg = `Chit ${this.model.name}-${this.model.value} is created successfully`; },
        (err: ErrorInfo) => { console.log(err); });
  }

}
