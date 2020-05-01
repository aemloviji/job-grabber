import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Job } from '../models/job';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private baseUrl = 'https://localhost:5001';
  constructor(private httpClient: HttpClient) { }

  list(): Observable<Job[]> {
    return this.httpClient
      .get(`https://localhost:5001/jobs`)
      .pipe(
        map(res => (res as any[]).map(this.toJob)),
        catchError(this.handleError));
  }

  private getHeaders() {
    const httpHeaders = new HttpHeaders();
    httpHeaders.append('Accept', 'application/json');
    return httpHeaders;
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }

  private toJob(data: any): Job {
    return {
      id: data.id,
      title: data.title,
      company: data.company
    };
  }
}


