import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideCardForumsComponent } from './side-card-forums.component';

describe('SideCardForumsComponent', () => {
  let component: SideCardForumsComponent;
  let fixture: ComponentFixture<SideCardForumsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SideCardForumsComponent]
    });
    fixture = TestBed.createComponent(SideCardForumsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
