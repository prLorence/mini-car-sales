import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-find-listing',
  templateUrl: './find-listing.component.html',
  styleUrls: ['./find-listing.component.css']
})
export class FindListingComponent {
  public listing: CarListing;
  public searchForm: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  searchListing() {
    this.http.get<CarListing>(this.baseUrl + `api/carlisting/find?id=${this.searchForm.get('searchId').value}`).subscribe(
      result => {
        this.listing = result;
      },
      error => {
        console.error(error);
        // Handle the error case if needed
      }
    );
  }

  ngOnInit() {
    this.searchForm = new FormGroup({
      searchId: new FormControl(null)
    });
  }
}

interface CarListing {
  year?: string;
  make?: string;
  model?: string;
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
