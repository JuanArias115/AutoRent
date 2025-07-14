import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewRent } from './view-rent';

describe('ViewRent', () => {
  let component: ViewRent;
  let fixture: ComponentFixture<ViewRent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewRent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewRent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
