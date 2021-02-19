import { Component, Inject, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  Client, WeatherForecast
} from 'src/shared/service-proxies/service-proxies';


import { AppComponentBase } from 'src/app/shared/app-component-base';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent extends AppComponentBase
{
  public forecasts: WeatherForecast[];

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  constructor(injector: Injector, _client:Client)
  {
    super(injector);
    let x = 10;
    
    _client.weatherForecast(x).subscribe(result => {
      this.forecasts = result;
   }, error => console.error(error));

    //http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //  this.forecasts = result;
    //}, error => console.error(error));
  }
}

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}
