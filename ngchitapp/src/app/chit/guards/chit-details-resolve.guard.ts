import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { IGetChit } from '../models/i-get-chit';
import { ErrorInfo } from '../../500/error-info';
import { ChitService } from '../services/chit.service';

@Injectable({
  providedIn: 'root'
})
export class ChitDetailsResolveGuard implements Resolve<IGetChit | ErrorInfo> {

  constructor(private chitService: ChitService) { }

  resolve(next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<IGetChit | ErrorInfo> {
    const id = +(next.paramMap.get('id'));
    return this.chitService.getChitById(id);
  }
}
