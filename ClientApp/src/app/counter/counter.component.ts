import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Student } from './student';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html',
  providers: [DataService]
})
export class CounterComponent {
  student: Student = new Student();
  students: Student[];
  tableMode: boolean = true;  
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadGroup();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  loadGroup() {
    //this.dataService.getGroups()
    //  .subscribe(data => {
    //    this.groups = Array.of(data);
    //  })
    this.dataService.getStudents()
      .subscribe((data: Student[]) => this.students = data);
  }
  // сохранение данных
  save() {
    if (this.student.StudentId == null) {
      this.dataService.createStudent(this.student)
        .subscribe((data: Student) => this.students.push(data));
    } else {
      this.dataService.updateStudent(this.student)
        .subscribe(data => this.loadGroup());
    }
    this.cancel();
  }
  editStudent(p: Student) {
    this.student = p;
  }
  cancel() {
    this.student = new Student();
    this.tableMode = true;
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}
