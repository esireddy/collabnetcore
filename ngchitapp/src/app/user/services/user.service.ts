import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SignupUser } from '../models/signup-user';
import { ErrorInfo } from '../../500/error-info';
import { IGetUser } from '../models/i-get-user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = 'http://localhost:60080/api/users';

  errObj = new ErrorInfo();

  constructor(private http: HttpClient) { }

  createUser(user: SignupUser): Observable<IGetUser | ErrorInfo> {
    return this.http
      .post<IGetUser>(this.baseUrl,
        user,
        { headers: new HttpHeaders({ 'Accept': 'application/json' }) })
        .pipe(
          catchError(this.handleError)
        );
  }

  getUsers(searchTerm: string): Observable<IGetUser[]> {
    const url = this.baseUrl + `?searchTerm=${searchTerm ? searchTerm : 'undefined'}`;
    console.log(url);
    return this.http
      .get<IGetUser[]>(url,
        { headers: new HttpHeaders({ 'Accept': 'application/json' }) });
  }

  private handleError(err: HttpErrorResponse): Observable<ErrorInfo> {
    this.errObj.errorNumber = err.status;
    this.errObj.message = err.error;
    return throwError(this.errObj);
  }
}
