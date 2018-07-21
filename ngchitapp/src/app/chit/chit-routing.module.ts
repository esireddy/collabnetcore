import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChitListComponent } from './chit-list/chit-list.component';
import { ChitCreateComponent } from './chit-create/chit-create.component';
import { AuthGuard } from '../user/guards/auth.guard';
import { ChitListResolveGuard } from './guards/chit-list-resolve.guard';
import { ChitDetailsComponent } from './chit-details/chit-details.component';
import { ChitDetailsResolveGuard } from './guards/chit-details-resolve.guard';
import { ChitEditComponent } from './chit-edit/chit-edit.component';
import { ChitEditDefaultComponent } from './chit-edit-default/chit-edit-default.component';
import { ChitEditManagerComponent } from './chit-edit-manager/chit-edit-manager.component';
import { ChitEditUsersComponent } from './chit-edit-users/chit-edit-users.component';
import { ChitEditGuardGuard } from './guards/chit-edit-guard.guard';

const chitRoutes: Routes = [
  {
    path: 'chits',
    // canActivate: [AuthGuard],
    children: [
      { path: '', component: ChitListComponent, resolve: { chitlist: ChitListResolveGuard } },
      { path: 'create', component: ChitCreateComponent },
      { path: ':id', component: ChitDetailsComponent, resolve: { chitDetails: ChitDetailsResolveGuard } },
      {
        path: ':id/edit', component: ChitEditComponent,
        canDeactivate: [ChitEditGuardGuard],
        resolve: { chitDetails: ChitDetailsResolveGuard },
        children: [
          { path: '', redirectTo: 'default', pathMatch: 'full' },
          { path: 'default', component: ChitEditDefaultComponent },
          { path: 'manager', component: ChitEditManagerComponent },
          { path: 'users', component: ChitEditUsersComponent }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(chitRoutes)],
  exports: [RouterModule]
})
export class ChitRoutingModule { }
