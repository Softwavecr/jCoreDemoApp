import { Component } from '@angular/core';
import { ContactItemsClient, ContactItemDto } from '../web-api-client';
import { ContactItemsClient2 } from '../web-api-contact-client';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  public contacts: ContactItemDto[];

//https://stackoverflow.com/questions/40649799/create-component-to-specific-module-with-angular-cli
//https://angular-2-training-book.rangle.io/modules/multiple-elements
//https://www.pluralsight.com/guides/angular-module-declaring-components

  //constructor() {
  constructor(private client: ContactItemsClient2) {    
    // client.getContactItemsWithPagination(1,1,10).subscribe(result => {
    //   this.contacts = result;
    // }, error => console.error(error));

    client.getContactItems().subscribe(result => {
      this.contacts = result;
    }, error => console.error(error));

    

    // constructor(private client: ContactItemsClient) {
    //   client.get().subscribe(result => {
    //     this.contacts = result;
    //   }, error => console.error(error));
    // }

  }
}
