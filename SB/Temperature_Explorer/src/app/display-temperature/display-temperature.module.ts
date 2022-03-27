import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShowTemperatureComponent } from './show-temperature/show-temperature.component';
import { AngularMaterialModule } from '../angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [ShowTemperatureComponent],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
})
export class DisplayTemperatureModule {}
