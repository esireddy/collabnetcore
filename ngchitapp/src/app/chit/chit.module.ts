import { NgModule } from '@angular/core';

import { ChitRoutingModule } from './chit-routing.module';
import { ChitListComponent } from './chit-list/chit-list.component';
import { SharedModule } from '../shared/shared.module';
import { CustomMaterialModule } from '../shared/custom-material.module';
import { CreateChitComponent } from './create-chit/create-chit.component';
import { ChitDetailsComponent } from './chit-details/chit-details.component';
import { ChitService } from './services/chit.service';

@NgModule({
  declarations: [
    ChitListComponent,
    CreateChitComponent,
    ChitDetailsComponent
  ],
  imports: [
    SharedModule,
    CustomMaterialModule,
    ChitRoutingModule
  ],
  providers: [
    ChitService
  ]
})
export class ChitModule { }
