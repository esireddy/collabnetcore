import { NgModule } from '@angular/core';

import { ChitRoutingModule } from './chit-routing.module';
import { ChitListComponent } from './chit-list/chit-list.component';
import { SharedModule } from '../shared/shared.module';
import { CustomMaterialModule } from '../shared/custom-material.module';
import { ChitCreateComponent } from './chit-create/chit-create.component';
import { ChitDetailsComponent } from './chit-details/chit-details.component';
import { ChitService } from './services/chit.service';
import { ChitStartComponent } from './chit-start/chit-start.component';
import { UserService } from '../user/services/user.service';

@NgModule({
  declarations: [
    ChitListComponent,
    ChitCreateComponent,
    ChitDetailsComponent,
    ChitCreateComponent,
    ChitStartComponent
  ],
  imports: [
    SharedModule,
    CustomMaterialModule,
    ChitRoutingModule
  ],
  providers: [
    ChitService,
    UserService
  ]
})
export class ChitModule { }
