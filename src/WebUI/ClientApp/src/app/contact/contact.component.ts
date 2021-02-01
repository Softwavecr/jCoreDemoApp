import { Component } from '@angular/core';
import { ContactsClient, ContactPaginatedDto } from '../web-api-client';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  public contacts: ContactPaginatedDto[];

  constructor(private client: ContactsClient) {    
    client.getContactsWithPagination(1,10).subscribe(result => {
      this.contacts = result.items;
    }, error => console.error(error));
  }
}
