import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedPostsV2Component } from './feed-posts-v2.component';

describe('FeedPostsV2Component', () => {
  let component: FeedPostsV2Component;
  let fixture: ComponentFixture<FeedPostsV2Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FeedPostsV2Component]
    });
    fixture = TestBed.createComponent(FeedPostsV2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
