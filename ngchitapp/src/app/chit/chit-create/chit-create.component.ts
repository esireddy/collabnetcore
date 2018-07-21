import { Component, OnInit } from '@angular/core';
import { CreateChit } from '../models/create-chit';
import { NgForm } from '@angular/forms';
import { ChitService } from '../services/chit.service';
import { IGetChit } from '../models/i-get-chit';
import { ErrorInfo } from '../../500/error-info';
import { TitleCasePipe } from '@angular/common';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-chit-create',
  templateUrl: './chit-create.component.html',
  styleUrls: ['./chit-create.component.scss']
})
export class ChitCreateComponent implements OnInit {

  model = new CreateChit();

  chit$: IGetChit;

  constructor(private chitService: ChitService, private titlecasePipe: TitleCasePipe) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.chitService
        .createChit(this.model)
        .subscribe(
          (data: IGetChit) => {
            this.chit$ = data;
            setTimeout(() => {
              Swal({
                title: 'Success',
                text: 'Create Chit Action!',
                customClass: 'swal-size-sm',
                type: 'success'
              });
              form.resetForm();
            }, 500);
          },
          (err: ErrorInfo) => { console.log(err); });
    }
  }

  capitalize(event: any): void {
    if (event.target.name === 'chitname') {
      this.model.name = this.titlecasePipe.transform(this.model.name);
    }
  }

}
