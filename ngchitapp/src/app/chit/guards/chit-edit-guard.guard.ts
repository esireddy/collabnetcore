import { Injectable } from '@angular/core';
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ChitEditComponent } from '../chit-edit/chit-edit.component';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class ChitEditGuardGuard implements CanDeactivate<ChitEditComponent> {

  canDeactivate(component: ChitEditComponent): Promise<boolean> | boolean {
    if (component.isDirty) {
      const chitname = component.chit.name;
      // return confirm(`Navigate away amd lose all changes to ${chitname}`);
      return Swal({
        title: 'Are you sure?',
        text: `Navigate away and lose all changes to ${chitname}`,
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ok'
      }).then((result) => {
        if (result.value) {
          return true;
        }
        if (result.dismiss) {
          return false;
        }
      });
    }
    return true;
  }
}
