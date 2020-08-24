import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { User, UserRegistration, UserUpdate } from 'src/app/shared/models/user';
import { environment } from 'src/environments/environment';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = environment.userApi;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.url);
  }

  getUser(id: number): Observable<UserUpdate>{
    return this.http.get<UserUpdate>(this.url + '/' + id);
  }

  /** POST: add a new user to the server */
  addUser(user: UserRegistration): Observable<UserRegistration> {
    return this.http.post<UserRegistration>(this.url, user, this.httpOptions).pipe(
      tap(_ => console.log(`added user`)),
      catchError(this.handleError<UserRegistration>('addUser'))
    );
  }

  /** PUT: update user */
  updateUser(user: UserUpdate): Observable<UserUpdate> {
    return this.http.put<UserUpdate>(this.url, user, this.httpOptions).pipe(
      tap(_ => console.log(`updated user`)),
      catchError(this.handleError<UserUpdate>('updateUser'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
