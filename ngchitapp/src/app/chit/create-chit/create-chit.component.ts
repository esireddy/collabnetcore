import { Component, OnInit } from '@angular/core';
import { CreateChit } from '../models/create-chit';
import { NgForm } from '@angular/forms';
import { ChitService } from '../services/chit.service';
import { IGetChit } from '../models/i-get-chit';
import { ErrorInfo } from '../../500/error-info';

@Component({
  selector: 'app-create-chit',
  templateUrl: './create-chit.component.html',
  styleUrls: ['./create-chit.component.scss']
})
export class CreateChitComponent implements OnInit {

  model = new CreateChit();

  chit$: IGetChit;

  isChitCreated = false;

  constructor(private chitService: ChitService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.chitService
        .createChit(this.model)
        .subscribe(
          (data: IGetChit) => {
            this.chit$ = data;
            this.isChitCreated = true;
            setTimeout(() => {
              this.isChitCreated = false;
              form.resetForm();
            }, 2000);
          },
          (err: ErrorInfo) => { console.log(err); });
    }
  }

}
