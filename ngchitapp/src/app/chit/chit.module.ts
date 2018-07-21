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
import { ChitEditComponent } from './chit-edit/chit-edit.component';
import { ChitEditDefaultComponent } from './chit-edit-default/chit-edit-default.component';
import { ChitEditManagerComponent } from './chit-edit-manager/chit-edit-manager.component';
import { ChitEditUsersComponent } from './chit-edit-users/chit-edit-users.component';

@NgModule({
  declarations: [
    ChitListComponent,
    ChitCreateComponent,
    ChitDetailsComponent,
    ChitCreateComponent,
    ChitStartComponent,
    ChitEditComponent,
    ChitEditDefaultComponent,
    ChitEditManagerComponent,
    ChitEditUsersComponent
  ],
  imports: [
    SharedModule,
    CustomMaterialModule,
    ChitRoutingModule
  ],
  providers: [
  ]
})
export class ChitModule { }
