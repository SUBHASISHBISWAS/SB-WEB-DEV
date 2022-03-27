import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from   './app.component';


import { WelcomeComponent } from './home/welcome.component';
import { ProductModule } from './Products/product.module';

@NgModule({
  declarations: 
  [
    AppComponent,
    WelcomeComponent
  ],
  imports: 
  [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ProductModule,
    RouterModule.forRoot([
      {path:'welcome', component: WelcomeComponent},
      {path:'', redirectTo :'welcome', pathMatch:'full'},
      {path:'**', redirectTo :'welcome', pathMatch:'full'},
    ],{useHash:false}),
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
