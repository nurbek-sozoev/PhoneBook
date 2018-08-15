import { Component} from '@angular/core';
import { Contact } from "../models/contact";
import { ContactService } from "../contact.service";
import { Observable } from "rxjs/Observable";
import { Subject } from "rxjs/Subject";
import { debounceTime, distinctUntilChanged, switchMap } from "rxjs/operators";

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html'
})

export class ContactListComponent {
  contacts: Observable<Contact[]>;

  private searchCriterias = new Subject<string>();

  constructor(private contactService: ContactService) {
    console.log("Search");
    this.search('');
  }

  search(searchCriteria: string) {
    this.searchCriterias.next(searchCriteria)
  }

  ngOnInit(): void {
    this.contacts = this.searchCriterias.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((term: string) => this.contactService.searchContacts(term))
    );
  }

}
