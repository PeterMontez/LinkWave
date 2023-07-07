import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { FeedPostsComponent } from './feed-posts/feed-posts.component';
import { FeedPostsV2Component } from './feed-posts-v2/feed-posts-v2.component';
import { MainFeedComponent } from './main-feed/main-feed.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SearchFormComponent } from './search-form/search-form.component';
import { SideCardsComponent } from './side-cards/side-cards.component';
import { UserCardComponent } from './user-card/user-card.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ForumSearchComponent } from './forum-search/forum-search.component';

const routes: Routes = [
  { path: "", component: LandingPageComponent },
  { path: "login", component: LoginPageComponent },
  { path: "register", component: SignUpComponent },
  { path: "home", component: MainFeedComponent},
  { path: "forums/:param", component : ForumSearchComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
