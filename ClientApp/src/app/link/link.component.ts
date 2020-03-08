import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Link } from '../common/link.model';

@Component({
  selector: 'app-link',
  templateUrl: './link.component.html'
})
export class LinkComponent {
  public links: Link[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Link[]>(baseUrl + 'api\\link').subscribe(result => {
      this.links = result;
    }, error => console.error(error));
  }
}
