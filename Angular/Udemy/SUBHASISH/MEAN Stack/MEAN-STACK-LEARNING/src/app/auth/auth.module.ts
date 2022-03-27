import { NgModule } from '@angular/core';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { AngularMaterialModule } from '../angular-material.module';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthRoutingModule } from './auth.routing-module';

@NgModule({
  declarations: [SignupComponent, LoginComponent],
  imports: [
    FormsModule,
    AngularMaterialModule,
    CommonModule,
    RouterModule,
    AuthRoutingModule,
  ],
  exports: [],
})
export class AuthModule {}
