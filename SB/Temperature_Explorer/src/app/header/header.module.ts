import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header.component';
import { AngularMaterialModule } from '../angular-material.module';

@NgModule({
  declarations: [HeaderComponent],
  imports: [CommonModule, AngularMaterialModule],
  exports: [HeaderComponent],
})
export class HeaderModule {}
