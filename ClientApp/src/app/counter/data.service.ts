import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from './student';

@Injectable()
export class DataService {

  constructor(private http: HttpClient) {
  }

  getStudents() {
    return this.http.get("/WeatherForecast/GetSavedStudent");
  }

  createStudent(student: Student) {
    return this.http.post("/WeatherForecast/SaveFile", student);
  }
  updateStudent(student: Student) {

    return this.http.put("/WeatherForecast/UpdateStudent", student);
  }
}
