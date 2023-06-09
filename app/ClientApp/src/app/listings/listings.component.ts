import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-listings',
  templateUrl: './listings.component.html',
  styleUrls: ['./listings.component.css']
})
export class ListingsComponent {
  public carListings: CarListing[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<CarListing[]>(baseUrl + 'api/carlisting/all').subscribe(result => {
      this.carListings = result;
    }, error => console.error(error));
  }
}

interface CarListing {
  id: number;
  year: string;
  make: string;
  model: string;
  comments: string;
  driveAwayPrice?: number;
  excludingGovernmentCharges?: number;
  nonDealerDetails?: {
    name: string;
    contactNumber: string;
  }
  dealerDetails?: {
    name: string;
    email: string;
    contactNumber: string;
    abn: string;
  }
}
