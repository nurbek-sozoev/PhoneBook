import {Component, OnInit} from '@angular/core';
import {ContactService} from "../contact.service";
import {ActivatedRoute} from "@angular/router";
import {Location} from "@angular/common";
import {Contact} from "../models/contact";
import {PhoneNumber} from "../models/phone-number";

@Component({
  selector: 'app-contact-create',
  templateUrl: './contact-create.component.html'
})
export class ContactCreateComponent implements OnInit {
  contact: Contact;

  constructor(
    private contactService: ContactService,
    private route: ActivatedRoute,
    private location: Location
  ) {
    this.contact = new Contact();
    this.contact.phoneNumbers = [];
  }

  ngOnInit() {
  }

  goBack(): void {
    this.location.back();
  }

  create(): void {
    if (this.contact.name && this.contact.organization) {
      this.contactService.createContact(this.contact).subscribe(() => this.goBack())
    } else {
      alert('Заполните форму!');
    }
  }

  addPhone(type: string, phone: string): void{
    this.contact.phoneNumbers.push({type: type, number: phone} as PhoneNumber)
  }

  deletePhone(phoneNumber: PhoneNumber): void{
    this.contact.phoneNumbers = this.contact.phoneNumbers.filter(pn => pn !== phoneNumber);
  }
}
