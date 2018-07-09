import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChitListComponent } from './chit-list/chit-list.component';
import { CreateChitComponent } from './create-chit/create-chit.component';
import { AuthGuard } from '../user/guards/auth.guard';
import { ChitListResolveGuard } from './guards/chit-list-resolve.guard';
import { ChitDetailsComponent } from './chit-details/chit-details.component';
import { ChitDetailsResolveGuard } from './guards/chit-details-resolve.guard';

const chitRoutes: Routes = [
  {
    path: 'chits',
    // canActivate: [AuthGuard],
    children: [
      { path: '', component: ChitListComponent, resolve: { chitlist: ChitListResolveGuard } },
      { path: 'create', component: CreateChitComponent },
      { path: ':id', component: ChitDetailsComponent, resolve: { chitDetails: ChitDetailsResolveGuard } }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(chitRoutes)],
  exports: [RouterModule]
})
export class ChitRoutingModule { }
