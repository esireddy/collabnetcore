import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AddChitComponent } from '../chit/add-chit/add-chit.component';
import { ChitModule } from '../chit/chit.module';
import { ListChitComponent } from '../chit/list-chit/list-chit.component';

const routes: Routes = [
  {
    path: 'admin', component: AdminComponent, children: [
      { path: '', redirectTo: 'addChit', pathMatch: 'full' },
      { path: 'addChit', component: AddChitComponent }
    ]
  },
  { path: 'listChit', component: ListChitComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes),
    ChitModule],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
