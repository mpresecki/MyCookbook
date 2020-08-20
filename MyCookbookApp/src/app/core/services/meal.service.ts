import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/shared/models/user';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { Meal, MealInsertModel, MealsByDay } from 'src/app/shared/models/meal';

@Injectable({
  providedIn: 'root'
})
export class MealService {
  private baseUrl = environment.mealApi;
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

  getMeals(): Observable<MealsByDay[]> {
    const url = this.baseUrl + '?userId=' + this.currentUser.id;
    return this.http.get<MealsByDay[]>(url).pipe(
      tap(_ =>
        console.log('fetched meals')),
        catchError(this.handleError<MealsByDay[]>('getMeals', []))
    );
  }

  /** POST: add a new meal to the server */
  addMeal(meal: MealInsertModel): Observable<MealInsertModel> {
    return this.http.post<MealInsertModel>(this.baseUrl, meal, this.httpOptions).pipe(
      tap(_ => console.log(`added meal`)),
      catchError(this.handleError<MealInsertModel>('addMeal'))
    );
  }

  /** PUT: update meal */
  updateMeal(meal: MealInsertModel): Observable<MealInsertModel> {
    return this.http.put<MealInsertModel>(this.baseUrl, meal, this.httpOptions).pipe(
      tap(_ => console.log(`updated meal`)),
      catchError(this.handleError<MealInsertModel>('updateMeal'))
    );
  }

  /** DELETE: delete meal */
  deleteMeal(mealId: number): Observable<number> {
    const url = `${this.baseUrl}/${mealId}`;
    return this.http.delete<number>(url).pipe(
      tap(_ => console.log(`deleted meal`)),
      catchError(this.handleError<number>('deleteMeal'))
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
