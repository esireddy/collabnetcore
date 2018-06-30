import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { AddChit } from '../models/add-chit';
import { Observable } from 'rxjs';
import { IGetChit } from '../dtos/i-get-chit';
import { ErrorInfo } from '../../error/error-info';
import 'rxjs/add/operator/catch';


@Injectable({
  providedIn: 'root'
})
export class ChitService {

  baseUrl = 'http://localhost:53694/api/chit';
  errorObj: ErrorInfo;

  constructor(private http: HttpClient) { }

  addChit(model: AddChit): Observable<IGetChit | ErrorInfo> {
    return this.http.post<IGetChit>(
      this.baseUrl,
      model,
      { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) })
      .catch(this.handleError);
  }

  getChits(): Observable<IGetChit[]> {
    return this.http.get<IGetChit[]>(
      this.baseUrl,
      { headers: new HttpHeaders({ 'Accept': 'application/json' }) });
  }

  private handleError(error: HttpErrorResponse) {
    this.errorObj.errorNumber = error.status;
    this.errorObj.message = error.error;
    return Observable.throw(this.errorObj);
  }
}
