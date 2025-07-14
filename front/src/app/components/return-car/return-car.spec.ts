import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnCar } from './return-car';

describe('ReturnCar', () => {
  let component: ReturnCar;
  let fixture: ComponentFixture<ReturnCar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReturnCar]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReturnCar);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
