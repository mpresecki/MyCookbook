import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { CookbookRecipe } from 'src/app/shared/models/recipe';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { AuthenticationService } from './authentication.service';
import { User } from 'src/app/shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class CookbookService {
  private baseUrl = environment.recipeApi;
  private currentUser: User;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
    ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  getCookbookRecipes(): Observable<CookbookRecipe[]> {
    const url = `${this.baseUrl}/Cookbook?userId=${this.currentUser.id}`;
    return this.http.get<CookbookRecipe[]>(url).pipe(
      tap(_ =>
        console.log('fetched cookbook recipes')),
        catchError(this.handleError<CookbookRecipe[]>('getCookbookRecipes', []))
    );
  }

  /** POST: add a new recipe to the cookbook */
  addCookbookRecipe(recipeId: number, userId: number): Observable<any> {
    const cookbookRecipe = { recipeId, userId };
    return this.http.post<any>(this.baseUrl + '/Cookbook', cookbookRecipe, this.httpOptions).pipe(
      tap(_ => console.log(`added cookbook recipe`)),
      catchError(this.handleError<any>('addCookbookRecipe'))
    );
  }

  /** DELETE: delete cookbook recipe */
  deleteCookbookRecipe(recipeId: number, userId: number): Observable<any> {
    const url = `${this.baseUrl}/Cookbook?recipeId=${recipeId}&userId=${userId}`;
    return this.http.delete<number>(url).pipe(
      tap(_ => console.log(`deleted cookbook recipe`)),
      catchError(this.handleError<any>('deleteCookbookRecipe'))
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
