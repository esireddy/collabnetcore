import { NgModule } from '@angular/core';
import { AddChitComponent } from './add-chit/add-chit.component';
import { CustomMaterialModule } from '../shared/custom-material.module';
import { ListChitComponent } from './list-chit/list-chit.component';

@NgModule({
  imports: [
    CustomMaterialModule
  ],
  declarations: [AddChitComponent, ListChitComponent]
})
export class ChitModule { }
