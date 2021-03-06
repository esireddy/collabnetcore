import { Injectable } from '@angular/core';
import { ErrorInfo } from '../../500/error-info';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
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
      .pipe(
        catchError(this.handleError)
      );
  }

  getChits(): Observable<IGetChit[] | ErrorInfo> {
    return this.http
      .get<IGetChit[]>(
        this.baseUrl,
        { headers: new HttpHeaders({ 'Accept': 'application/json' }) })
      .pipe(
        catchError(this.handleError)
      );
  }

  getChitById(id: number): Observable<IGetChit | ErrorInfo> {
    const url = this.baseUrl + `/${id}`;
    return this.http
      .get<IGetChit>(
        url,
        { headers: new HttpHeaders({ 'Accept': 'application/json' }) })
      .pipe(
        catchError(this.handleError)
      );
  }

  updateChit(id: number, jsonPatchDoc: any[]): any | ErrorInfo {
    const url = this.baseUrl + `/${id}`;

    return this.http.patch(
      url,
      jsonPatchDoc,
      { headers: new HttpHeaders({ 'Content-Type': 'application/json-patch+json' }) })
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(err: HttpErrorResponse): Observable<ErrorInfo> {
    this.errorObj.errorNumber = err.status;
    this.errorObj.message = err.error;
    return throwError(this.errorObj);
  }
}
