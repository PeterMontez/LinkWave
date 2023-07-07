import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';

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
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ForumFeedComponent } from './forum-feed/forum-feed.component';
import { NewPostComponent } from './new-post/new-post.component';
import { SideCardForumsComponent } from './side-card-forums/side-card-forums.component';
import { ForumCardComponent } from './forum-card/forum-card.component';
import { ForumSearchComponent } from './forum-search/forum-search.component';

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
    UserCardComponent,
    LandingPageComponent,
    ForumFeedComponent,
    NewPostComponent,
    SideCardForumsComponent,
    ForumCardComponent,
    ForumSearchComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    FormsModule,

    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
