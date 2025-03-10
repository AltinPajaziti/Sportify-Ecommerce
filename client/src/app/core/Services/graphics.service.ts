import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/envirement';


@Injectable({
  providedIn: 'root'
})
export class GraphicsService {
  private api = environment.api_Url + 'Graphic'; // Base URL for the API

  constructor(private http: HttpClient) {}

  getMonthlySales(): Observable<any> {
    return this.http.get(`${this.api}/Get-Monthly`)
      .pipe(catchError(this.handleError));
  }


  getYearlySales(): Observable<any> {
    return this.http.get(`${this.api}/Get-Year-data`)
      .pipe(catchError(this.handleError));
  }

 
  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = `Server Error: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(() => new Error(errorMessage));
  }
}
