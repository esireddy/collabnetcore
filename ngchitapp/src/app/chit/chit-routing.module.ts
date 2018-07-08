import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChitListComponent } from './chit-list/chit-list.component';
import { CreateChitComponent } from './create-chit/create-chit.component';
import { AuthGuard } from '../user/guards/auth.guard';

const chitRoutes: Routes = [
  {
    path: 'chits',
    canActivate: [AuthGuard],
    children: [
      { path: '', component: ChitListComponent },
      { path: 'create', component: CreateChitComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(chitRoutes)],
  exports: [RouterModule]
})
export class ChitRoutingModule { }
