import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contact } from "../models/contact";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public contacts: Contact[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Contact[]>(baseUrl + 'api/SampleData/Contacts').subscribe(result => {
      this.contacts = result;
    }, error => console.error(error));
  }
}

