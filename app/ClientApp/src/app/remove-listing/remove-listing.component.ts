import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-remove-listing',
  templateUrl: './remove-listing.component.html',
  styleUrls: ['./remove-listing.component.css']
})
export class RemoveListingComponent {
  public deleteForm: FormGroup;
  public isRemoved: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  removeListing() {
    this.http.delete(this.baseUrl + `api/carlisting/remove?id=${this.deleteForm.get('listingId').value}`).subscribe(
      () => {
        console.log('remove listing successfully')
        this.isRemoved = true;
      },
      error => {
        console.error(error);
        // Handle the error case if needed
      }
    );
  }

  ngOnInit() {
    this.deleteForm = new FormGroup({
      listingId: new FormControl(null)
    });
  }
}

