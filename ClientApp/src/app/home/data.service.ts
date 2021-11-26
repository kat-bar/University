import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Group } from './group';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) {
    }

  getGroups() {
    return this.http.get("/WeatherForecast/GetSavedGroup");
    }

    createGroup(group: Group) {
      return this.http.post("/WeatherForecast/SaveGroup", group);
    }
    updateGroup(group: Group) {

      return this.http.put("/WeatherForecast/UpdateGroup", group);
    }
}
