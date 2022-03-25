import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Temperature } from 'src/app/models/Temperature.model';
import { TemperatureService } from '../temperature.service';

@Component({
  selector: 'app-show-temperature',
  templateUrl: './show-temperature.component.html',
  styleUrls: ['./show-temperature.component.css'],
})
export class ShowTemperatureComponent implements OnInit {
  form!: FormGroup;
  temperature: string = '';
  longText = this.temperature;
  constructor(private temperatureService: TemperatureService) {}

  ngOnInit(): void {
    this.temperatureService.getTemperature();
    this.temperatureService
      .getTemperatureUpdateListener()
      .subscribe((temperature: string) => {
        console.log(`Temperature Is : ${this.temperature}`);
        this.temperature = temperature;
        this.longText = this.temperature;
      });
  }
  onGetTemperature() {
    this.temperatureService.getTemperature();
  }
}
