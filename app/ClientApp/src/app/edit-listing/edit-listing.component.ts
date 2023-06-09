import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit-listing',
  templateUrl: './edit-listing.component.html',
  styleUrls: ['./edit-listing.component.css']
})
export class EditListingComponent implements OnInit {
  public listingToEdit: CarListing;
  public editForm: FormGroup;
  public searchForm: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  searchListing() {
    this.http.get<CarListing>(this.baseUrl + `api/carlisting/find?id=${this.searchForm.get('searchId').value}`).subscribe(
      result => {
        this.listingToEdit = result;
        this.initializeEditForm();
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

  initializeEditForm() {
    this.editForm = new FormGroup({
      comments: new FormControl(this.listingToEdit.comments),
      driveAwayPrice: new FormControl(this.listingToEdit.driveAwayPrice),
      excludingGovernmentCharges: new FormControl(this.listingToEdit.excludingGovernmentCharges)
    });
  }

  updateListing() {
    if (this.editForm.valid) {
      const updatedListing: CarListing = {
        comments: this.editForm.get('comments').value,
        driveAwayPrice: this.editForm.get('driveAwayPrice').value,
        excludingGovernmentCharges: this.editForm.get('excludingGovernmentCharges').value
      };

      this.http.put(this.baseUrl + 'api/carlisting/update?id=2', updatedListing).subscribe(
        () => {
          // Update successful
          console.log('Listing updated successfully!');
        },
        error => {
          console.error('Error updating listing:', error);
          // Handle the error case if needed
        }
      );
    }
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
