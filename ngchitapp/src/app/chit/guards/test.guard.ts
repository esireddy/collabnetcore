import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { ChitEditDefaultComponent } from '../chit-edit-default/chit-edit-default.component';

@Injectable({
  providedIn: 'root'
})
export class TestGuard implements CanDeactivate<ChitEditDefaultComponent> {
  canDeactivate(component: ChitEditDefaultComponent): boolean {
    alert('test guard');
    return true;
  }
}
