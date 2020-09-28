import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';


import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { PhoneNumber } from '../model/phonenumber';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class PhoneBookService {
  constructor(private http: HttpClient) { }

  // get phonebook
  getPhoneBook(url: string): Observable<PhoneNumber[]> {
    return this.http.get<PhoneNumber[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  // get all phonenumber data
  getAllPhoneNumbers(url: string): Observable<PhoneNumber[]> {
    return this.http.get<PhoneNumber[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  // insert new phonenumber details JSON.stringify(phonenumber)
  addPhoneNumber(url: string, phonenumber: PhoneNumber): Observable<any> {
    return this.http.post(url, JSON.stringify(phonenumber), httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // update phonenumber details
  updatePhoneNumber(url: string, id: number, phonenumber: PhoneNumber): Observable<any> {
    const newurl = `${url}?id=${id}`;
    return this.http.put(newurl, phonenumber, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // delete phonenumber information
  deletePhoneNumber(url: string, id: number): Observable<any> {
    const newurl = `${url}?id=${id}`; // DELETE api/phonenumber?id=42
    return this.http.delete(newurl, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // custom handler
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
    return throwError('Something bad happened; please try again later.');
  }
}
