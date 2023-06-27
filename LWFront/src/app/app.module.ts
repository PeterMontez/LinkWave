import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { SearchFormComponent } from './search-form/search-form.component';
import { FeedPostsComponent } from './feed-posts/feed-posts.component';
import { MainFeedComponent } from './main-feed/main-feed.component';
import { FeedPostsV2Component } from './feed-posts-v2/feed-posts-v2.component';
import { SideCardsComponent } from './side-cards/side-cards.component';
import { UserCardComponent } from './user-card/user-card.component';

import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    LoginPageComponent,
    SignUpComponent,
    SideBarComponent,
    SearchFormComponent,
    FeedPostsComponent,
    MainFeedComponent,
    FeedPostsV2Component,
    SideCardsComponent,
    UserCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,

    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
