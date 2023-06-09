import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ListingsComponent } from './listings/listings.component';
import { PostListingComponent } from './post-listing/post-listing.component';
import { RemoveListingComponent } from './remove-listing/remove-listing.component';
import { EditListingComponent } from './edit-listing/edit-listing.component';

import { ReactiveFormsModule } from '@angular/forms';
import { FindListingComponent } from './find-listing/find-listing.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ListingsComponent,
    PostListingComponent,
    RemoveListingComponent,
    EditListingComponent,
    FindListingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ListingsComponent, pathMatch: 'full' },
      { path: 'edit', component: EditListingComponent },
      { path: 'post', component: PostListingComponent },
      { path: 'remove', component: RemoveListingComponent },
      { path: 'search', component: FindListingComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
