import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindListingComponent } from './find-listing.component';

describe('FindListingComponent', () => {
  let component: FindListingComponent;
  let fixture: ComponentFixture<FindListingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FindListingComponent]
    });
    fixture = TestBed.createComponent(FindListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
