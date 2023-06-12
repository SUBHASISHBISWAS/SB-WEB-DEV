import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowTemperatureComponent } from './show-temperature.component';

describe('ShowTemperatureComponent', () => {
  let component: ShowTemperatureComponent;
  let fixture: ComponentFixture<ShowTemperatureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowTemperatureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowTemperatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
