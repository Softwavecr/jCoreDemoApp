import { Component } from '@angular/core';
import { WeatherForecastClient, RootObject } from '../web-api-client';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecast: RootObject;
  
  city:any;
  temp:any;
  feels_like:any;
  pressure:any;
  humidity:any;

  constructor(private client: WeatherForecastClient) {
    client.get().subscribe(result => {
      this.forecast = result;

      this.city = result.name;
      this.temp = result.main.temp;
      this.feels_like = result.main.feels_like;
      this.pressure = result.main.pressure;
      this.humidity = result.main.humidity;

    }, error => console.error(error));
  }
}
