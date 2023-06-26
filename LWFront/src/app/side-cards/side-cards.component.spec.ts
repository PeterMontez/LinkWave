import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideCardsComponent } from './side-cards.component';

describe('SideCardsComponent', () => {
  let component: SideCardsComponent;
  let fixture: ComponentFixture<SideCardsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SideCardsComponent]
    });
    fixture = TestBed.createComponent(SideCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
