import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumFeedComponent } from './forum-feed.component';

describe('ForumFeedComponent', () => {
  let component: ForumFeedComponent;
  let fixture: ComponentFixture<ForumFeedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ForumFeedComponent]
    });
    fixture = TestBed.createComponent(ForumFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
