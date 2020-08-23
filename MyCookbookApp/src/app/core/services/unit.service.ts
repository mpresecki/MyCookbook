import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/shared/models/user';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ConversionModel } from 'src/app/shared/models/conversion-model';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UnitService {

  private baseUrl = environment.conversionApi;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

constructor(
  private http: HttpClient
  ) {}

  /** PUT: convert units */
  convertUnits(conversion: ConversionModel): Observable<ConversionModel> {
    return this.http.put<ConversionModel>(this.baseUrl + '/units', conversion, this.httpOptions).pipe(
      tap(_ => console.log(`units converted`)),
      catchError(this.handleError<ConversionModel>('convertUnits'))
    );
  }

  /** PUT: convert temperature */
  convertTemperature(conversion: ConversionModel): Observable<ConversionModel> {
    return this.http.put<ConversionModel>(this.baseUrl + '/temperature', conversion, this.httpOptions).pipe(
      tap(_ => console.log(`temperature converted`)),
      catchError(this.handleError<ConversionModel>('convertTemperature'))
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
