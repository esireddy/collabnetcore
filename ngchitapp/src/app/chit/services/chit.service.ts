import { Injectable } from '@angular/core';
import { ErrorInfo } from '../../500/error-info';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs-compat';
import { IGetChit } from '../models/i-get-chit';
import { CreateChit } from '../models/create-chit';


@Injectable({
  providedIn: 'root'
})
export class ChitService {

  baseUrl = 'http://localhost:60080/api/chits';

  errorObj = new ErrorInfo();

  constructor(private http: HttpClient) { }

  createChit(model: CreateChit): Observable<IGetChit | ErrorInfo> {
    return this.http
      .post<IGetChit>(
        this.baseUrl,
        model,
        { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) })
      .catch(this.handleError);
  }

  getChits(): Observable<IGetChit[] | ErrorInfo> {
    return this.http
      .get<IGetChit[]>(
        this.baseUrl,
        { headers: new HttpHeaders({ 'Accept': 'application/json' }) })
      .catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse): Observable<ErrorInfo> {
    this.errorObj.errorNumber = err.status;
    this.errorObj.message = err.error;
    return Observable.throw(this.errorObj);
  }
}
