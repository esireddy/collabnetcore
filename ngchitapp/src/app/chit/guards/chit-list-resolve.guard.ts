import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { IGetChit } from '../models/i-get-chit';
import { ErrorInfo } from '../../500/error-info';
import { ChitService } from '../services/chit.service';

@Injectable({
  providedIn: 'root'
})
export class ChitListResolveGuard implements Resolve<IGetChit[] | ErrorInfo> {

  constructor(private chitService: ChitService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<IGetChit[] | ErrorInfo> {
    return this.chitService.getChits();
  }

}
