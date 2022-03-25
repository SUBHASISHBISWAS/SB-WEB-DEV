import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowTemperatureComponent } from './display-temperature/show-temperature/show-temperature.component';
import { HeaderComponent } from './header/header.component';

const routes: Routes = [{ path: '', component: ShowTemperatureComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
