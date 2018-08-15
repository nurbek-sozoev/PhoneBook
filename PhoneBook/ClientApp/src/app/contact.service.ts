import { Injectable } from '@angular/core';
import { Contact } from "./models/contact";
import { HttpClient } from "@angular/common/http";
import { catchError, tap } from "rxjs/operators";
import { of } from "rxjs/observable/of";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ContactService {
  private contactsUrl = 'api/contact';

  constructor(private http: HttpClient) {}

  searchContacts(searchCriteria: string): Observable<Contact[]> {
    searchCriteria = searchCriteria.trim();

    return this.http.get<Contact[]>(`${this.contactsUrl}/?searchCriteria=${searchCriteria}`).pipe(
      tap(contacts => console.log("fetched data")),
      catchError(this.handleError<Contact[]>('searchContacts', []))
    );
  }

  private handleError<T> (service, result?: T) {
    return (error: any): Observable<T> => {
      console.log(`Call service ${service}`);
      console.error(error);
      return of(result as T);
    };
  }

}
