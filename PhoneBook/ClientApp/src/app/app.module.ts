import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { ContactRowComponent } from './contact-row/contact-row.component';
import { ContactService } from "./contact.service";
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactListComponent}  from "./contact-list/contact-list.component";
import { NavbarComponent } from './navbar/navbar.component';
import {AppRoutesModule} from "./app.routes.module";

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactRowComponent,
    ContactDetailsComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    AppRoutesModule
  ],
  providers: [
    ContactService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
