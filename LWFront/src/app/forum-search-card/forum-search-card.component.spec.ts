import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumSearchCardComponent } from './forum-search-card.component';

describe('ForumSearchCardComponent', () => {
  let component: ForumSearchCardComponent;
  let fixture: ComponentFixture<ForumSearchCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ForumSearchCardComponent]
    });
    fixture = TestBed.createComponent(ForumSearchCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
