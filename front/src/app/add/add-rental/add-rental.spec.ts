import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRental } from './add-rental';

describe('AddRental', () => {
  let component: AddRental;
  let fixture: ComponentFixture<AddRental>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRental]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRental);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
