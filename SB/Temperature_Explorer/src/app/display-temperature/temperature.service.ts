import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { Temperature } from '../models/Temperature.model';

const SERVER_URL = environment.apiUrl + '/temperature/';
@Injectable({
  providedIn: 'root',
})
export class TemperatureService {
  private temperatureUpdated = new Subject<string>();

  constructor(private http: HttpClient, private router: Router) {}

  getTemperatureUpdateListener() {
    return this.temperatureUpdated.asObservable();
  }
  getPosts() {}

  getTemperature() {
    return this.http
      .get<{
        message: string;
        temperature: string;
      }>(SERVER_URL)
      .subscribe((result) => {
        this.temperatureUpdated.next(result.temperature);
      });
  }
}
