import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { Temperature } from '../models/Temperature.model';
import { City } from '../models/City';

const SERVER_URL = environment.apiUrl + '/temperature/';
@Injectable({
  providedIn: 'root',
})
export class TemperatureService {
  private temperatureUpdated = new Subject<any>();
  private cities: City[] = [];
  constructor(private http: HttpClient, private router: Router) {}

  getTemperatureUpdateListener() {
    return this.temperatureUpdated.asObservable();
  }
  getPosts() {}

  getTemperature() {
    return this.http
      .get<{
        message: string;
        cities: any[];
      }>(SERVER_URL)
      .pipe(
        map((serverResponse) => {
          return {
            cities: serverResponse.cities.map((city) => {
              return {
                name: city.name,
                capital: city.state,
                country: city.country,
                population: city.population,
                regions: city.regions,
              } as City;
            }),
          };
        })
      )
      .subscribe((result) => {
        this.cities = result.cities;
        console.log(result.cities);
        this.temperatureUpdated.next(this.cities);
      });
  }
}
