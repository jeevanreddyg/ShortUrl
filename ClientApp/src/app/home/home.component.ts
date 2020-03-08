import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Link } from '../common/link.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public link: Link;
  public baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.link = new Link(); 
    this.link.longUrl = "http://pasteUrl.com";
    this.baseUrl = baseUrl;
  }

  onSubmit() {
    // Do Post and show generated URL
    this.http.post<any>(this.baseUrl + 'api\\link\\createshortlink', { longUrl: this.link.longUrl }).subscribe(result => {
      this.link = result;
    }, error => console.error(error));
    //this.link.shortUrl = "Generated URL";
  }
}
