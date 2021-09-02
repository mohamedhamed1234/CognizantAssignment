import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public listofcars: Warehouse[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Warehouse[]>(environment.apiEndPoint + 'api/WarehouseData/WarehouseCars').subscribe(result => {
      this.listofcars = result;
    }, error => console.error(error));
  }


  public currentCartTotal = 0;

  public AddToCard(price) {
    this.currentCartTotal = this.currentCartTotal + price;
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Warehouse {
  _id: string;
  name: string;
  location: Location;
  cars: Cars;
}

interface Cars {
  location: string;
  name: string;
  vehicles: Vehicle[];
}

interface Vehicle {
  _id: string;
  make: string;
  model: string;
  year_model: string;
  price: string;
  licensed: boolean;
  date_added: string;
}

interface Location {
  lat: string;
  long: string;
}


