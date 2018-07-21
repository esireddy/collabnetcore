import { Component, OnInit, Injector } from '@angular/core';
import { IGetChit } from '../models/i-get-chit';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorInfo } from '../../500/error-info';
import { NgForm } from '@angular/forms';
import { TitleCasePipe } from '@angular/common';
import { ChitEditComponent } from '../chit-edit/chit-edit.component';
import { ChitService } from '../services/chit.service';

@Component({
  selector: 'app-chit-edit-default',
  templateUrl: './chit-edit-default.component.html',
  styleUrls: ['./chit-edit-default.component.scss']
})
export class ChitEditDefaultComponent implements OnInit {

  chit: IGetChit;
  minDate = new Date();
  parentComponent: ChitEditComponent;
  jsonPatchDoc: any = [];

  constructor(private route: ActivatedRoute,
    private titlecasePipe: TitleCasePipe,
    private router: Router,
    private injector: Injector,
    private chitService: ChitService) {
    this.parentComponent = this.injector.get(ChitEditComponent);
  }

  ngOnInit() {
    this.getChit();
  }

  getChit(): void {
    this.route
      .parent
      .data
      .subscribe((data: IGetChit) => { this.chit = data['chitDetails']; console.log(this.chit); },
        (err: ErrorInfo) => { console.log(err); });
  }

  onSubmit(form: NgForm): void {

    if (form.valid) {
      this.makePatchData(form);

      this.chitService
        .updateChit(
          this.chit.id,
          this.jsonPatchDoc)
        .subscribe();

      this.parentComponent.reset();

      if (this.chit.managerId === 0) {
        this.router.navigate(['/chits', this.chit.id, 'edit', 'manager']);
      } else if (this.chit.noOfUsers !== this.chit.chitUsers.length) {
        this.router.navigate(['/chits', this.chit.id, 'edit', 'users']);
      } else {
        this.router.navigate(['/chits']);
      }
    }
  }

  makePatchData(form: NgForm): void {

    if (form.form.controls.chitname.dirty) {
      this.jsonPatchDoc.push({ 'op': 'replace', 'path': '/name', 'value': form.form.controls.chitname.value });
    }

    if (form.form.controls.chitvalue.dirty) {
      this.jsonPatchDoc.push({ 'op': 'replace', 'path': '/value', 'value': form.form.controls.chitvalue.value });
    }

    if (form.form.controls.noOfMonths.dirty) {
      this.jsonPatchDoc.push({ 'op': 'replace', 'path': '/noOfMonths', 'value': form.form.controls.noOfMonths.value });
    }

    if (form.form.controls.noOfUsers.dirty) {
      this.jsonPatchDoc.push({ 'op': 'replace', 'path': '/noOfUsers', 'value': form.form.controls.noOfUsers.value });
    }

    if (form.form.controls.auctionDate.dirty) {
      this.jsonPatchDoc.push({ 'op': 'replace', 'path': '/auctionDate', 'value': form.form.controls.auctionDate.value });
    }
  }

  capitalize(event: any): void {
    if (event.target.name === 'chitname') {
      this.chit.name = this.titlecasePipe.transform(this.chit.name);
    }
  }

}
