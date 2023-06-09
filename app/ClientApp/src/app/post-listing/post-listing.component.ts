import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-post-listing',
  templateUrl: './post-listing.component.html',
  styleUrls: ['./post-listing.component.css']
})
export class PostListingComponent {
  public createForm: FormGroup;
  public nonDealerDetailsForm: FormGroup;
  public dealerDetailsForm: FormGroup;
  public priceType: string = 'dap';
  public dealerType: string = 'non-dealer';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.initializeFormControls();
  }

  initializeFormControls() {
    this.nonDealerDetailsForm = new FormGroup({
      name: new FormControl(null),
      contactNumber: new FormControl(null)
    });

    this.dealerDetailsForm = new FormGroup({
      name: new FormControl(null),
      contactNumber: new FormControl(null),
      email: new FormControl(null),
      abn: new FormControl(null)
    });

    this.createForm = new FormGroup({
      year: new FormControl(null),
      make: new FormControl(null),
      model: new FormControl(null),
      comments: new FormControl(null),
      driveAwayPrice: new FormControl(0),
      excludingGovernmentCharges: new FormControl(),
      nonDealerDetails: this.nonDealerDetailsForm ?? null,
      dealerDetails: this.dealerDetailsForm ?? null
    });
  }

  createListing() {
    const newListing: CarListing = {
      year: this.createForm.get('year').value,
      make: this.createForm.get('make').value,
      model: this.createForm.get('model').value,
      comments: this.createForm.get('comments').value,
      driveAwayPrice: this.createForm.get('driveAwayPrice').value ?? 0,
      excludingGovernmentCharges: this.createForm.get('excludingGovernmentCharges').value ?? 0,
      nonDealerDetails: {
        name: this.nonDealerDetailsForm.get('name').value,
        contactNumber: this.nonDealerDetailsForm.get('contactNumber').value
      },
      dealerDetails: {
        name: this.dealerDetailsForm.get('name').value,
        contactNumber: this.dealerDetailsForm.get('contactNumber').value,
        email: this.dealerDetailsForm.get('email').value,
        abn: this.dealerDetailsForm.get('abn').value
      },
    };

    console.log(newListing);

    this.http.post(this.baseUrl + 'api/carlisting/create', newListing).subscribe(
      () => {
        // Update successful
        console.log('Listing created successfully!');
      },
      error => {
        console.error('Error updating listing:', error);
        // Handle the error case if needed
      }
    );
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
