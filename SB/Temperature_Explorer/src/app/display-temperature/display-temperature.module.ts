import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShowTemperatureComponent } from './show-temperature/show-temperature.component';
import { AngularMaterialModule } from '../angular-material.module';

@NgModule({
  declarations: [ShowTemperatureComponent],
  imports: [CommonModule, AngularMaterialModule],
})
export class DisplayTemperatureModule {}
