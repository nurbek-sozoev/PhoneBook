import { Component, OnInit} from '@angular/core';
import { Contact } from "../models/contact";
import { ContactService } from "../contact.service";

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html'
})

export class ContactListComponent implements OnInit {
  contacts: Contact[];

  constructor(private contactService: ContactService) {
    console.log("Search");
  }

  search(searchCriteria: string) {
    this.contactService.searchContacts(searchCriteria).subscribe(contacts => this.contacts = contacts);
  }

  ngOnInit() {
    this.search('');
  }
}
