import { Component, Input, OnInit } from '@angular/core';
import { Contact } from "../models/contact";
import { ContactService } from "../contact.service";
import { ActivatedRoute } from "@angular/router";
import { Location } from '@angular/common';
import {PhoneNumber} from "../models/phone-number";

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html'
})

export class ContactDetailsComponent implements OnInit {
  @Input() contact: Contact;

  constructor(
    private contactService: ContactService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.getContact();
  }

  getContact(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.contactService.getContact(id)
      .subscribe(contact => this.contact = contact);
  }

  goBack(): void {
    this.location.back();
  }

  update(): void {
    if (this.contact.name && this.contact.organization) {
      this.contactService.updateContact(this.contact).subscribe(() => this.goBack())
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
