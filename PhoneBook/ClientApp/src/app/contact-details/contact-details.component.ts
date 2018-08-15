import { Component, Input, OnInit } from '@angular/core';
import { Contact } from "../models/contact";
import { ContactService } from "../contact.service";
import { ActivatedRoute } from "@angular/router";
import { Location } from '@angular/common';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
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
    this.contactService.updateContact(this.contact).subscribe(() => this.goBack())
  }

}
