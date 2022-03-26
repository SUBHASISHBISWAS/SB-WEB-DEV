import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { City } from 'src/app/models/City';
import { Temperature } from 'src/app/models/Temperature.model';
import { TemperatureService } from '../temperature.service';

@Component({
  selector: 'app-show-temperature',
  templateUrl: './show-temperature.component.html',
  styleUrls: ['./show-temperature.component.css'],
})
export class ShowTemperatureComponent implements OnInit {
  form!: FormGroup;
  cities: City[] = [];
  longText = this.cities;
  constructor(private temperatureService: TemperatureService) {}

  ngOnInit(): void {
    this.temperatureService.getTemperature();
    this.temperatureService
      .getTemperatureUpdateListener()
      .subscribe((cities: City[]) => {
        console.log(`Temperature Is : ${this.cities}`);
        this.cities = cities;
        this.longText = this.cities;
      });
  }
  onGetTemperature() {
    this.temperatureService.getTemperature();
  }
}
