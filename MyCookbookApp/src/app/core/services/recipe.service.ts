import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Recipe, RecipeInsert, RecipeModel } from '../../shared/models/recipe';
import { Ingredient } from '../../shared/models/ingredient';
import { AuthenticationService } from './authentication.service';
import { User } from 'src/app/shared/models/user';
import { RecipeCategory } from 'src/app/shared/models/recipe-category';
import { Skill } from 'src/app/shared/models/skill-types';
import { Unit } from 'src/app/shared/models/unit-types';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
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

  getRecipes(areUserRecipes = false): Observable<Recipe[]> {
    const url = this.baseUrl + '/Recipe?userId=' + this.currentUser.id + '&areUserRecipes=' + areUserRecipes;
    return this.http.get<Recipe[]>(url).pipe(
      tap(_ =>
        console.log('fetched recipes')),
        catchError(this.handleError<Recipe[]>('getRecipes', []))
    );
  }

  getRecipe(id: number): Observable<RecipeModel> {
    const url = `${this.baseUrl}/Recipe/${id}`;
    return this.http.get<RecipeModel>(url).pipe(
      tap(_ =>
        console.log('fetched recipe')),
        catchError(this.handleError<RecipeModel>('getRecipe'))
    );
  }

  /* GET ingredients whose name contains search term */
  searchIngredients(term: string, exactMatch: boolean = false): Observable<Ingredient[]> {
    if (!term.trim()) {
      return of([]);
    }
    const url = `${this.baseUrl}/Ingredient?name=${term}&exactMatch=${exactMatch}`;
    return this.http.get<Ingredient[]>(url).pipe(
      tap(x => x.length ?
        console.log(`found ingredients matching "${term}"`) :
        console.log(`no ingredients matching "${term}"`)),
      catchError(this.handleError<Ingredient[]>('searchIngredients', []))
    );
  }

   /** POST: add a new recipe to the server */
   addRecipe(recipe: RecipeInsert): Observable<RecipeInsert> {
    return this.http.post<RecipeInsert>(this.baseUrl + '/Recipe', recipe, this.httpOptions).pipe(
      tap(_ => console.log(`added recipe`)),
      catchError(this.handleError<RecipeInsert>('addRecipe'))
    );
  }

  /** PUT: update recipe */
  updateRecipe(recipe: RecipeInsert): Observable<RecipeInsert> {
    return this.http.put<RecipeInsert>(this.baseUrl + '/Recipe', recipe, this.httpOptions).pipe(
      tap(_ => console.log(`updated recipe`)),
      catchError(this.handleError<RecipeInsert>('updateRecipe'))
    );
  }

  /** DELETE: delete recipe */
  deleteRecipe(recipeId: number): Observable<any> {
    const url = `${this.baseUrl}/Recipe/${recipeId}`;
    return this.http.delete<number>(url).pipe(
      tap(_ => console.log(`deleted recipe`)),
      catchError(this.handleError<RecipeInsert>('deleteRecipe'))
    );
  }

  /** GET: get ingredient */
  getIngredients(): Observable<Ingredient[]> {
    const url = `${this.baseUrl}/Ingredient`;
    return this.http.get<Ingredient[]>(url).pipe(
      tap(_ =>
        console.log('fetched ingredients')),
        catchError(this.handleError<Ingredient[]>('getIngredients', []))
    );
  }

  /** POST: add a new ingredient to the server */
  addIngredient(ingredient: Ingredient): Observable<Ingredient> {
    return this.http.post<Ingredient>(this.baseUrl + '/Ingredient', ingredient, this.httpOptions).pipe(
      tap(_ => console.log(`added ingredient`)),
      catchError(this.handleError<Ingredient>('addIngredient'))
    );
  }

  /** PUT: update ingredient */
  updateIngredient(ingredient: Ingredient): Observable<Ingredient> {
    return this.http.put<Ingredient>(this.baseUrl + '/Ingredient', ingredient, this.httpOptions).pipe(
      tap(_ => console.log(`updated ingredient`)),
      catchError(this.handleError<RecipeInsert>('updateIngredient'))
    );
  }

  /** DELETE: delete ingredient */
  deleteIngredient(ingredientId: number): Observable<any> {
    const url = `${this.baseUrl}/Ingredient/${ingredientId}`;
    return this.http.delete<number>(url).pipe(
      tap(_ => console.log(`deleted ingredient`)),
      catchError(this.handleError<RecipeInsert>('deleteIngredient'))
    );
  }

  /** GET: get recipe categories */
  getRecipeCategories(): Observable<RecipeCategory[]> {
    const url = this.baseUrl + '/Recipe/categories';
    return this.http.get<RecipeCategory[]>(url).pipe(
      tap(_ =>
        console.log('fetched recipe categories')),
        catchError(this.handleError<RecipeCategory[]>('getRecipeCategories', []))
    );
  }

  /** GET: get skill levels */
  getSkillLevels(): Observable<Skill[]> {
    const url = this.baseUrl + '/Recipe/skills';
    return this.http.get<Skill[]>(url).pipe(
      tap(_ =>
        console.log('fetched skill levels')),
        catchError(this.handleError<Skill[]>('getSkillLevels', []))
    );
  }

  /** GET: get units */
  getUnits(): Observable<Unit[]> {
    const url = this.baseUrl + '/Recipe/units';
    return this.http.get<Unit[]>(url).pipe(
      tap(_ =>
        console.log('fetched units')),
        catchError(this.handleError<Unit[]>('getUnits', []))
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
